using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZastitaInformacijaProjekat
{
    internal class CodeFiles
    {
        private const int ChunkSize = 65_536; 
        public async Task<string> EncodeFileWithHeaderAsync(
            string inputFile, string outputFolder, byte[] key)
        {
            FileInfo fi = new FileInfo(inputFile);

            string hash = ComputeFileSHA1(inputFile);

            FileMetadata meta = new FileMetadata
            {
                FileName = Path.GetFileName(inputFile),
                OriginalExtension = fi.Extension,
                FileSize = fi.Length,
                CreatedAt = fi.CreationTime,
                EncryptedDate = DateTime.Now,
                EncryptionAlgorithm = "RC6_OFB",
                HashAlgorithm = "SHA1",
                Hash = hash,
                MimeType = GetMimeType(fi.Extension),
                ChunkSize = ChunkSize,
                Version = "2.0"
            };

            string jsonMeta = JsonSerializer.Serialize(meta,
                new JsonSerializerOptions { WriteIndented = true });
            byte[] metaBytes = Encoding.UTF8.GetBytes(jsonMeta);

            Directory.CreateDirectory(outputFolder);
            string outputFile = Path.Combine(outputFolder,
                Path.GetFileNameWithoutExtension(inputFile) + "_encrypted.enc");

            using (FileStream output = new FileStream(
                outputFile, FileMode.Create, FileAccess.Write))
            {
                byte[] lenBytes = BitConverter.GetBytes(metaBytes.Length);
                await output.WriteAsync(lenBytes, 0, 4);
                await output.WriteAsync(metaBytes, 0, metaBytes.Length);

                byte[] iv = DeriveIV(key);
                RC6OFB ofb = new RC6OFB(key, iv);
                byte[] buf = new byte[ChunkSize];

                using (FileStream input = new FileStream(
                    inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    int read;
                    while ((read = await input.ReadAsync(buf, 0, buf.Length)) > 0)
                    {
                        ofb.Transform(buf, 0, read); // in-place XOR
                        await output.WriteAsync(buf, 0, read);
                    }
                }
            }

            File.AppendAllText("Log.txt",
                "Kodiran fajl " + outputFile + "    " + DateTime.Now + "\n");
            return outputFile;
        }

        // ── Decrypt ──────────────────────────────────────────────────────────

        public async Task DecodeFileWithHeaderAsync(
            string encodedFile, string outputFolder, byte[] key)
        {
            using (FileStream fs = new FileStream(
                encodedFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] lenBuf = new byte[4];
                await ReadExactlyAsync(fs, lenBuf, 4);
                int headerLen = BitConverter.ToInt32(lenBuf, 0);

                byte[] headerBytes = new byte[headerLen];
                await ReadExactlyAsync(fs, headerBytes, headerLen);

                FileMetadata meta = JsonSerializer.Deserialize<FileMetadata>(
                    Encoding.UTF8.GetString(headerBytes))
                    ?? throw new Exception("Neispravan format zaglavlja.");

                Directory.CreateDirectory(outputFolder);
                string outputFile = Path.Combine(outputFolder, meta.FileName);

                byte[] iv = DeriveIV(key);
                RC6OFB ofb = new RC6OFB(key, iv);

                byte[] buf = new byte[ChunkSize];
                long remaining = fs.Length - fs.Position;

                //IncrementalHash incrementalHash = IncrementalHash.CreateHash(HashAlgorithmName.SHA1);

                using (FileStream output = new FileStream(
                    outputFile, FileMode.Create, FileAccess.Write))
                {
                    while (remaining > 0)
                    {
                        int toRead = (int)Math.Min(buf.Length, remaining);
                        int read = await fs.ReadAsync(buf, 0, toRead);
                        if (read == 0) break;

                        ofb.Transform(buf, 0, read); // decrypt in-place

                        //incrementalHash.AppendData(buf, 0, read);

                        await output.WriteAsync(buf, 0, read);
                        remaining -= read;
                    }
                }

                //byte[] hashBytes = incrementalHash.GetHashAndReset();
                //string computedHex = BitConverter.ToString(hashBytes)
                //    .Replace("-", "").ToLower();
                string computedHex = ComputeFileSHA1(outputFile);

                if (!string.Equals(computedHex, meta.Hash,
                    StringComparison.OrdinalIgnoreCase))
                {
                    File.AppendAllText("Log.txt",
                        "HASH NEODGOVARA za " + meta.FileName +
                        "    " + DateTime.Now + "\n");

                    string exp = (meta.Hash != null && meta.Hash.Length >= 8)
                        ? meta.Hash.Substring(0, 8) : meta.Hash ?? "?";
                    string got = computedHex.Length >= 8
                        ? computedHex.Substring(0, 8) : computedHex;

                    throw new Exception(
                        "Integritet fajla narusen!\n" +
                        "Ocekivano: " + exp + "...\n" +
                        "Dobijeno:  " + got + "...");
                }

                File.AppendAllText("Log.txt",
                    "Dekodiran fajl " + outputFile + "    " + DateTime.Now + "\n");
            }
        }


        private static string ComputeFileSHA1(string filePath)
        {
            using (FileStream fs = new FileStream(
                filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                SHA1Impl sha1 = new SHA1Impl();
                byte[] hash = sha1.ComputeHash(fs);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
            
        }

        private static byte[] DeriveIV(byte[] key)
        {
            byte[] iv = new byte[16];
            for (int w = 0; w < 4; w++)
            {
                int b = w * 4;
                uint word = (uint)((key[b] << 24) |
                                   (key[b + 1] << 16) |
                                   (key[b + 2] << 8) |
                                    key[b + 3]);
                byte[] wb = BitConverter.GetBytes(word);
                Array.Copy(wb, 0, iv, b, 4);
            }
            return iv;
        }

        private static async Task ReadExactlyAsync(Stream s, byte[] buf, int count)
        {
            int total = 0;
            while (total < count)
            {
                int read = await s.ReadAsync(buf, total, count - total);
                if (read == 0)
                    throw new EndOfStreamException("Neocekivani kraj fajla.");
                total += read;
            }
        }


        public string SecureRandomString(int length = 16)
        {
            const string chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            byte[] data = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                rng.GetBytes(data);

            char[] result = new char[length];
            for (int i = 0; i < length; i++)
                result[i] = chars[data[i] % chars.Length];
            return new string(result);
        }

        private static readonly Dictionary<string, string> MimeMap =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { ".txt",  "text/plain" },
                { ".pdf",  "application/pdf" },
                { ".png",  "image/png" },
                { ".jpg",  "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".gif",  "image/gif" },
                { ".bmp",  "image/bmp" },
                { ".zip",  "application/zip" },
                { ".rar",  "application/x-rar-compressed" },
                { ".7z",   "application/x-7z-compressed" },
                { ".mp3",  "audio/mpeg" },
                { ".mp4",  "video/mp4" },
                { ".avi",  "video/x-msvideo" },
                { ".doc",  "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".xls",  "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { ".exe",  "application/octet-stream" },
                { ".bin",  "application/octet-stream" },
            };

        private static string GetMimeType(string ext)
        {
            string mime;
            return MimeMap.TryGetValue(ext, out mime) ? mime : "application/octet-stream";
        }
    }
}
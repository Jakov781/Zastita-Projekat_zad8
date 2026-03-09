using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZastitaInformacijaProjekat
{

    internal class FileMetadata
    {

        [JsonPropertyName("filename")]
        public string FileName { get; set; } = string.Empty;

        [JsonPropertyName("original_extension")]
        public string OriginalExtension { get; set; } = string.Empty;

        [JsonPropertyName("filesize")]
        public long FileSize { get; set; }


        [JsonPropertyName("created")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("encrypted")]
        public DateTime EncryptedDate { get; set; }


        [JsonPropertyName("algorithm")]
        public string EncryptionAlgorithm { get; set; } = "RC6_OFB";

        [JsonPropertyName("mode")]
        public string Mode { get; set; } = "OFB";

        [JsonPropertyName("hash_algorithm")]
        public string HashAlgorithm { get; set; } = "SHA1";


        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;


        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; } = "application/octet-stream";


        [JsonPropertyName("chunk_size")]
        public int ChunkSize { get; set; } = 65536;

        [JsonPropertyName("version")]
        public string Version { get; set; } = "2.0";


        public byte[] ToJsonBytes()
        {
            string json = JsonSerializer.Serialize(this,
                new JsonSerializerOptions { WriteIndented = false });
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        public static FileMetadata FromJsonBytes(byte[] data)
        {
            string json = System.Text.Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<FileMetadata>(json)
                   ?? throw new InvalidDataException("Neispravan JSON metadata.");
        }
    }
}

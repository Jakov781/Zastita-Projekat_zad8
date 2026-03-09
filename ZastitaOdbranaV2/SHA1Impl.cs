using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaInformacijaProjekat
{
    internal class SHA1Impl
    {
        private uint h0 = 0x67452301;
        private uint h1 = 0xEFCDAB89;
        private uint h2 = 0x98BADCFE;
        private uint h3 = 0x10325476;
        private uint h4 = 0xC3D2E1F0;

        public byte[] ComputeHash(byte[] data)
        {
            byte[] padded = Pad(data);
            ProcessBlocks(padded);
            return GetHash();
        }
        private void Initialize()
        {
            h0 = 0x67452301;
            h1 = 0xEFCDAB89;
            h2 = 0x98BADCFE;
            h3 = 0x10325476;
            h4 = 0xC3D2E1F0;
        }
        public byte[] ComputeHash(Stream stream)
        {
            Initialize();
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[8192];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);

                return ComputeHash(ms.ToArray());
            }
        }

        private byte[] Pad(byte[] input)
        {
            long bitLen = input.Length * 8L;

            int paddingBytes = (int)((56 - (input.Length + 1) % 64 + 64) % 64);

            byte[] padded = new byte[input.Length + 1 + paddingBytes + 8];

            Array.Copy(input, padded, input.Length);

            padded[input.Length] = 0x80;

            for (int i = 0; i < 8; i++)
                padded[padded.Length - 1 - i] = (byte)(bitLen >> (8 * i));

            return padded;
        }


        private void ProcessBlocks(byte[] data)
        {
            uint[] w = new uint[80];

            for (int i = 0; i < data.Length; i += 64)
            {
                for (int t = 0; t < 16; t++)
                {
                    w[t] = (uint)(data[i + 4 * t] << 24 |
                                  data[i + 4 * t + 1] << 16 |
                                  data[i + 4 * t + 2] << 8 |
                                  data[i + 4 * t + 3]);
                }

                for (int t = 16; t < 80; t++)
                    w[t] = RotateLeft(w[t - 3] ^ w[t - 8] ^ w[t - 14] ^ w[t - 16], 1);

                uint a = h0, b = h1, c = h2, d = h3, e = h4;

                for (int t = 0; t < 80; t++)
                {
                    uint f, k;

                    if (t < 20)
                    {
                        f = (b & c) | (~b & d);
                        k = 0x5A827999;
                    }
                    else if (t < 40)
                    {
                        f = b ^ c ^ d;
                        k = 0x6ED9EBA1;
                    }
                    else if (t < 60)
                    {
                        f = (b & c) | (b & d) | (c & d);
                        k = 0x8F1BBCDC;
                    }
                    else
                    {
                        f = b ^ c ^ d;
                        k = 0xCA62C1D6;
                    }

                    uint temp = RotateLeft(a, 5) + f + e + k + w[t];
                    e = d;
                    d = c;
                    c = RotateLeft(b, 30);
                    b = a;
                    a = temp;
                }

                h0 += a;
                h1 += b;
                h2 += c;
                h3 += d;
                h4 += e;
            }
        }

        private byte[] GetHash()
        {
            byte[] hash = new byte[20];
            WriteUInt(hash, 0, h0);
            WriteUInt(hash, 4, h1);
            WriteUInt(hash, 8, h2);
            WriteUInt(hash, 12, h3);
            WriteUInt(hash, 16, h4);
            return hash;
        }

        private void WriteUInt(byte[] buffer, int offset, uint value)
        {
            buffer[offset] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)value;
        }

        private uint RotateLeft(uint x, int n)
        {
            return (x << n) | (x >> (32 - n));
        }
    }
}

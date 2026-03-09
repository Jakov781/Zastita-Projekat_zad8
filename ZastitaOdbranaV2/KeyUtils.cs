using System.Security.Cryptography;
using System.Text;

namespace ZastitaInformacijaProjekat
{

    public static class KeyUtils
    {
        private const string ReadableChars =
            "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789";

        public static string GenerateReadableKey(int length)
        {
            var sb = new StringBuilder(length);
            var rng = RandomNumberGenerator.Create();
            byte[] buf = new byte[1];

            while (sb.Length < length)
            {
                rng.GetBytes(buf);
                int idx = buf[0] % ReadableChars.Length;
                sb.Append(ReadableChars[idx]);
            }

            return sb.ToString();
        }

        public static byte[] DeriveKey(string password, int length)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            byte[] key = new byte[length];
            System.Array.Copy(hash, key, System.Math.Min(length, hash.Length));
            return key;
        }
    }
}

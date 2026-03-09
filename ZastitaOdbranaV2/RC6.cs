using System;

namespace ZastitaInformacijaProjekat
{
    public class RC6
    {
        private const int w = 32;
        private const int r = 20;
        private const uint Pw = 0xB7E15163;
        private const uint Qw = 0x9E3779B9;

        private readonly uint[] S;

        public RC6(byte[] key)
        {
            S = KeySchedule(key);
        }

        private static uint[] KeySchedule(byte[] key)
        {
            int c = key.Length / 4;
            uint[] L = new uint[c];

            for (int i = key.Length - 1; i >= 0; i--)
                L[i / 4] = (L[i / 4] << 8) + key[i];

            uint[] Sched = new uint[2 * r + 4];
            Sched[0] = Pw;
            for (int i = 1; i < Sched.Length; i++)
                Sched[i] = (Sched[i - 1] + Qw);

            uint A = 0, B = 0;
            int iS = 0, iL = 0;
            int v = 3 * Math.Max(c, Sched.Length);

            for (int i = 0; i < v; i++)
            {
                A = Sched[iS] = RotateLeft((Sched[iS] + A + B), 3);
                B = L[iL] = RotateLeft((L[iL] + A + B), (int)(A + B));
                iS = (iS + 1) % Sched.Length;
                iL = (iL + 1) % c;
            }

            return Sched;
        }

        public void EncryptBlockInPlace(byte[] block, int offset = 0)
        {
            uint A = BitConverter.ToUInt32(block, offset);
            uint B = BitConverter.ToUInt32(block, offset + 4);
            uint C = BitConverter.ToUInt32(block, offset + 8);
            uint D = BitConverter.ToUInt32(block, offset + 12);

            B = (B + S[0]);
            D = (D + S[1]);

            for (int i = 1; i <= r; i++)
            {
                uint t = RotateLeft((B * (2 * B + 1)), 5);
                uint u = RotateLeft((D * (2 * D + 1)), 5);
                A = (RotateLeft((A ^ t), (int)(u & 31)) + S[2 * i]);
                C = (RotateLeft((C ^ u), (int)(t & 31)) + S[2 * i + 1]);
                uint tmp = A; A = B; B = C; C = D; D = tmp;
            }

            A = (A + S[2 * r + 2]);
            C = (C + S[2 * r + 3]);

            WriteUInt32(block, offset, A);
            WriteUInt32(block, offset + 4, B);
            WriteUInt32(block, offset + 8, C);
            WriteUInt32(block, offset + 12, D);
        }


        public byte[] EncryptBlock(byte[] input)
        {
            byte[] output = (byte[])input.Clone();
            EncryptBlockInPlace(output, 0);
            return output;
        }

        public byte[] DecryptBlock(byte[] input)
        {
            uint A = BitConverter.ToUInt32(input, 0);
            uint B = BitConverter.ToUInt32(input, 4);
            uint C = BitConverter.ToUInt32(input, 8);
            uint D = BitConverter.ToUInt32(input, 12);

            C = (C - S[2 * r + 3]);
            A = (A - S[2 * r + 2]);

            for (int i = r; i >= 1; i--)
            {
                uint tmp = D; D = C; C = B; B = A; A = tmp;
                uint u = RotateLeft((D * (2 * D + 1)), 5);
                uint t = RotateLeft((B * (2 * B + 1)), 5);
                C = (RotateRight((C - S[2 * i + 1]), (int)(t & 31)) ^ u);
                A = (RotateRight((A - S[2 * i]), (int)(u & 31)) ^ t);
            }

            D = (D - S[1]);
            B = (B - S[0]);

            byte[] output = new byte[16];
            WriteUInt32(output, 0, A);
            WriteUInt32(output, 4, B);
            WriteUInt32(output, 8, C);
            WriteUInt32(output, 12, D);
            return output;
        }


        private static uint RotateLeft(uint x, int y)
            => (x << (y & 31)) | (x >> (32 - (y & 31)));

        private static uint RotateRight(uint x, int y)
            => (x >> (y & 31)) | (x << (32 - (y & 31)));

        private static void WriteUInt32(byte[] buf, int off, uint val)
        {
            byte[] b = BitConverter.GetBytes(val);
            buf[off] = b[0];
            buf[off + 1] = b[1];
            buf[off + 2] = b[2];
            buf[off + 3] = b[3];
        }
    }
}

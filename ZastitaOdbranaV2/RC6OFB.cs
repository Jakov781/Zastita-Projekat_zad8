using System;
using System.IO;

namespace ZastitaInformacijaProjekat
{

    internal class RC6OFB
    {
        private readonly RC6 _rc6;

        private readonly byte[] _feedback = new byte[16];
        private readonly byte[] _keystreamBlock = new byte[16];
        private int _pos = 16; 

        public RC6OFB(byte[] key, byte[] iv)
        {
            if (iv == null || iv.Length != 16)
                throw new ArgumentException("IV mora biti tacno 16 bajta.");

            _rc6 = new RC6(key);
            Array.Copy(iv, _feedback, 16);
            _pos = 16;
        }

        public void Transform(byte[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (_pos == 16)
                {
                    Array.Copy(_feedback, _keystreamBlock, 16);
                    _rc6.EncryptBlockInPlace(_keystreamBlock);   
                    Array.Copy(_keystreamBlock, _feedback, 16);
                    _pos = 0;
                }
                buffer[offset + i] ^= _keystreamBlock[_pos++];
            }
        }

        public void ProcessStream(Stream input, Stream output)
        {
            byte[] buf = new byte[65_536];
            int read;
            while ((read = input.Read(buf, 0, buf.Length)) > 0)
            {
                Transform(buf, 0, read);
                output.Write(buf, 0, read);
            }
        }

        public byte[] Process(byte[] data)
        {
            byte[] result = (byte[])data.Clone();
            Transform(result, 0, result.Length);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaInformacijaProjekat
{
    public class Bifid
    {
        private char[,] testMatrix = {
        {'P', 'H', 'Q', 'G', 'M' },
        {'E', 'A', 'Y', 'L', 'N' },
        {'O', 'F', 'D', 'X', 'K' },
        {'R', 'C', 'V', 'S', 'Z' },
        {'W', 'D', 'U', 'T', 'I' }
        };


        // TEXT
        static char[,] GenerateMatrix(string key)
        {
            List<char> alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToList();

            byte[] hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(key));
            }

            int seed = BitConverter.ToInt32(hash, 0);
            Random rng = new Random(seed);

            for (int i = alphabet.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (alphabet[i], alphabet[j]) = (alphabet[j], alphabet[i]);
            }

            char[,] matrix = new char[5, 5];
            int index = 0;

            for (int r = 0; r < 5; r++)
                for (int c = 0; c < 5; c++)
                    matrix[r, c] = alphabet[index++];

            return matrix;
        }

        public string EncryptText(string text, string key, int space = 5)
        {
            List<int> listRow = new List<int>();
            List<int> listColumn = new List<int>();
            var matrix = GenerateMatrix(key);
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsLetter(text[i]))
                    continue;
                char codeChar = char.ToUpper(text[i]);
                if (codeChar == 'J')
                    codeChar = 'I';
                if (!char.IsLetter(codeChar))
                    continue;
                var (row, column) = FindCharInTable(codeChar, matrix);
                listRow.Add(row);
                listColumn.Add(column);
            }
            StringBuilder code = new StringBuilder();
            string stringRow = "";
            string stringColumn = "";
            for(int i = 0; i < listRow.Count; i++)
            {
                if(i % space == 0 && i != 0)
                {
                    code.Append(stringRow);
                    code.Append(stringColumn);
                    stringRow = "";
                    stringColumn = "";
                }
                stringRow += listRow[i] + 1;
                stringColumn += listColumn[i] + 1;
            }
            code.Append(stringRow);
            code.Append(stringColumn);

            return MakeStringFromTable(code.ToString(), matrix);

        }
        public string MakeStringFromTable(string s, char[,] matrix)
        {
            string sb = "";
            for(int i = 0; i < s.Length - 1; i += 2)
            {
                sb += (matrix[s[i] - '0' - 1, s[i+1] - '0' - 1]);
            }
            return sb.ToString();
        }
        public string GetPassFromText(string txt, char[,] matrix, int space)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (char c in txt)
            {
                var (row, col) = FindCharInTable(c, matrix);
                sb.Append(Convert.ToString(row));
                sb.Append(Convert.ToString(col));
                i++;
                if(i == space * 2)
                {
                    i = 0;
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        public string DecryptText(string encryptedText, string key, int space = 5)
        {
            try
            {

                char[,] matrix = GenerateMatrix(key);

                List<int> numbers = new List<int>();

                foreach (char c in encryptedText)
                {
                    var (row, col) = FindCharInTable(c, matrix);
                    numbers.Add(row + 1);
                    numbers.Add(col + 1);
                }

                StringBuilder result = new StringBuilder();

                for (int i = 0; i < numbers.Count; i += space * 2)
                {
                    int len = Math.Min(space * 2, numbers.Count - i);
                    var block = numbers.GetRange(i, len);

                    int half = block.Count / 2;

                    for (int j = 0; j < half; j++)
                    {
                        int r = block[j] - 1;
                        int c = block[j + half] - 1;
                        result.Append(matrix[r, c]);
                    }
                }

                return result.ToString();
            }
            catch
            {
                return "Bad code";
            }
        }
        public (int row, int column) FindCharInTable(char c, char[,] bifidTable)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (bifidTable[i, j] == c)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

    }
}

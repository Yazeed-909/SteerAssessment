using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteerAssessment
{
    public class Code
    {
        public string Value { get; private set; }
        public int Length { get; private set; }
        public int ColorCount { get; private set; }

        public Code(int length, int colorCount, string code = null)
        {
            Length = length;
            ColorCount = colorCount;

            if (!string.IsNullOrEmpty(code) && IsValidCode(code))
                Value = code;
            else
                Value = GenerateRandomCode();
        }

        public bool IsValidCode(string code)
        {
            return code.Length == Length &&
                code.All(c => c >= '0' && c < '0' + ColorCount) &&
                code.Distinct().Count() == Length;
        }

        private string GenerateRandomCode()
        {
            var digits = Enumerable.Range(0, ColorCount).Select(i => (char)('0' + i)).ToList();
            var rnd = new Random();
            var codeChars = new List<char>();
            for (int i = 0; i < Length; i++)
            {
                int idx = rnd.Next(digits.Count);
                codeChars.Add(digits[idx]);
                digits.RemoveAt(idx);
            }
            return new string(codeChars.ToArray());
        }
    }
}

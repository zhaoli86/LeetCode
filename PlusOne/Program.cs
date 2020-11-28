using System;

namespace PlusOne
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            int carry = 1;

            for (int i = digits.Length-1; i >=0 && carry>0; i--)
            {
                var r = digits[i] + carry;
                digits[i] = r % 10;
                carry = r / 10;
            }
            if (carry==0)
            {
                return digits;
            }

            var result = new int[digits.Length + 1];
            for (int i = 0; i < digits.Length; i++)
            {
                result[i + 1] = digits[i];
            }
            result[0] = carry;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

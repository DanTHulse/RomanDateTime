using System;
using System.Linq;
using System.Text;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate
{
    public static partial class RomanNumerals
    {
        /// <summary>
        /// Converts a string of Roman numerals to an integer.
        /// </summary>
        /// <param name="numerals">The Roman numerals to convert.</param>
        /// <returns>The integer representation of the Roman numerals</returns>
        public static int ToInt(string numerals)
        {
            var interger = 0;

            interger += numerals.Contains("IV") ? 4 : 0;
            numerals = numerals.Replace("IV", "");
            interger += numerals.Contains("IX") ? 9 : 0;
            numerals = numerals.Replace("IX", "");
            interger += numerals.Contains("XC") ? 90 : 0;
            numerals = numerals.Replace("XC", "");
            interger += numerals.Contains("CM") ? 900 : 0;
            numerals = numerals.Replace("CM", "");

            var nums = numerals.ToCharArray();

            interger += nums.Where(w => w == 'I').Count();
            interger += (nums.Where(w => w == 'V').Count() * 5);
            interger += (nums.Where(w => w == 'X').Count() * 10);
            interger += (nums.Where(w => w == 'L').Count() * 50);
            interger += (nums.Where(w => w == 'C').Count() * 100);
            interger += (nums.Where(w => w == 'D').Count() * 500);
            interger += (nums.Where(w => w == 'M').Count() * 1000);

            return interger;
        }
    }
}
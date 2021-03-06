﻿using System;
using System.Linq;
using System.Text;
using RomanDateTime.Enums;

namespace RomanDateTime.Helpers
{
    /// <summary>
    /// Class used to handle and convert Roman numerals
    /// </summary>
    public static class RomanNumerals
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

        public static string ToRomanNumerals(this int num, NumeralStyles style = NumeralStyles.Subtractive) => ToRomanNumerals((int?)num, style);

        public static string ToRomanNumerals(this int? num, NumeralStyles style = NumeralStyles.Subtractive)
        {
            var sb = new StringBuilder();

            if (num.HasValue && num != 0)
            {
                var thousands = Math.DivRem(num.Value, 1000, out var tRem);
                var hundreds = Math.DivRem(tRem, 100, out var hRem);
                var tens = Math.DivRem(hRem, 10, out var tenRem);

                switch (style)
                {
                    case NumeralStyles.Subtractive:
                        sb.AppendRepeat(Numerals.M, thousands);
                        SubtractiveNumerals(sb, hundreds, (Numerals.C, Numerals.D, Numerals.M));
                        SubtractiveNumerals(sb, tens, (Numerals.X, Numerals.L, Numerals.C));
                        SubtractiveNumerals(sb, tenRem, (Numerals.I, Numerals.V, Numerals.X));
                        break;
                    case NumeralStyles.Additive:
                        sb.AppendRepeat(Numerals.M, thousands);
                        AdditiveNumerals(sb, hundreds, (Numerals.C, Numerals.D, Numerals.M));
                        AdditiveNumerals(sb, tens, (Numerals.X, Numerals.L, Numerals.C));
                        AdditiveNumerals(sb, tenRem, (Numerals.I, Numerals.V, Numerals.X));
                        break;
                }
            }

            return sb.ToString();
        }

        private static void SubtractiveNumerals(StringBuilder sb, int val, (Numerals units, Numerals fives, Numerals tens) numerals)
        {
            sb.AppendIf(numerals.fives, val.Between(5, 8));
            sb.AppendIf($"{numerals.units}{numerals.tens}", val == 9);
            sb.AppendIfRepeat(numerals.units, val.Between(5, 8), (val - 5));
            sb.AppendIf($"{numerals.units}{numerals.fives}", val == 4);
            sb.AppendIfRepeat(numerals.units, val.Between(1, 3), val);
        }

        private static void AdditiveNumerals(StringBuilder sb, int val, (Numerals units, Numerals fives, Numerals tens) numerals)
        {
            sb.AppendIf(numerals.fives, val.Between(5, 9));
            sb.AppendIfRepeat(numerals.units, val.Between(5, 9), (val - 5));
            sb.AppendIfRepeat(numerals.units, val.Between(1, 4), val);
        }
    }
}

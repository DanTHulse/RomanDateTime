using System;
using System.Text;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers.RomanNumerals
{
    public static partial class RomanNumerals
    {
        /// <summary>
        /// Converts an integer to Roman numerals, in the specified style.
        /// </summary>
        /// <param name="num">The integer to convert to numerals.</param>
        /// <param name="style">The style to use, if left defaults to subtractive.</param>
        /// <returns>A string of Roman numerals representing the integer</returns>
        public static string ToRomanNumerals(this int num, NumeralStyles style = NumeralStyles.Subtractive) => ToRomanNumerals((int?)num, style);

        /// <summary>
        /// Converts an integer to Roman numerals, in the specified style.
        /// </summary>
        /// <param name="num">The integer to convert to numerals.</param>
        /// <param name="style">The style to use, if left defaults to subtractive.</param>
        /// <returns>A string of Roman numerals representing the integer</returns>
        public static string ToRomanNumerals(this int? num, NumeralStyles style = NumeralStyles.Subtractive)
        {
            var sb = new StringBuilder();

            if (num.HasValue && num != 0)
            {
                var thousands = Math.DivRem(num.Value, 1000, out var tRem);
                var hundreds = Math.DivRem(tRem, 100, out var hRem);
                var tens = Math.DivRem(hRem, 10, out var tenRem);

                return style switch
                {
                    NumeralStyles.Subtractive => sb.AppendRepeat(Numerals.M, thousands)
                                                   .SubtractiveNumerals(hundreds, (Numerals.C, Numerals.D, Numerals.M))
                                                   .SubtractiveNumerals(tens, (Numerals.X, Numerals.L, Numerals.C))
                                                   .SubtractiveNumerals(tenRem, (Numerals.I, Numerals.V, Numerals.X))
                                                   .ToString(),
                    NumeralStyles.Additive => sb.AppendRepeat(Numerals.M, thousands)
                                                   .AdditiveNumerals(hundreds, (Numerals.C, Numerals.D, Numerals.M))
                                                   .AdditiveNumerals(tens, (Numerals.X, Numerals.L, Numerals.C))
                                                   .AdditiveNumerals(tenRem, (Numerals.I, Numerals.V, Numerals.X))
                                                   .ToString(),
                    _ => sb.ToString()
                };
            }

            return sb.ToString();
        }

        private static StringBuilder SubtractiveNumerals(this StringBuilder sb, int val, (Numerals units, Numerals fives, Numerals tens) numerals)
        {
            return sb.AppendIf(numerals.fives, val.Between(5, 8))
                     .AppendIf($"{numerals.units}{numerals.tens}", val == 9)
                     .AppendIfRepeat(numerals.units, val.Between(5, 8), (val - 5))
                     .AppendIf($"{numerals.units}{numerals.fives}", val == 4)
                     .AppendIfRepeat(numerals.units, val.Between(1, 3), val);
        }

        private static StringBuilder AdditiveNumerals(this StringBuilder sb, int val, (Numerals units, Numerals fives, Numerals tens) numerals)
        {
            return sb.AppendIf(numerals.fives, val.Between(5, 9))
                     .AppendIfRepeat(numerals.units, val.Between(5, 9), (val - 5))
                     .AppendIfRepeat(numerals.units, val.Between(1, 4), val);
        }
    }
}
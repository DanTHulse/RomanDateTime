namespace RomanDate.Extensions.Maths
{
    public static partial class MathEx
    {
        /// <summary>
        /// Retuns the Modulo of the value, with number wrap for negative values, e.g. -1 % 8 = 7
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="n">The divisor</param>
        /// <returns>The remainder of the modulus operation (non-negative)</returns>
        public static int Modulo(int a, int n) => (a % n + n) % n;
    }
}

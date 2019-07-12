namespace API.RomanDate.Helpers
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// Checks if the provided string contains any of the specified characters
        /// </summary>
        /// <param name="str">The string to check</param>
        /// <param name="characters">The specified characters to check against</param>
        /// <returns>True if the string contains any of the specified characters</returns>
        public static bool ContainsAny(this string str, params char[] characters)
        {
            foreach (var character in characters)
            {
                if (str.Contains(character.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

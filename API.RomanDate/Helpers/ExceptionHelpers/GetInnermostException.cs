using System;

namespace API.RomanDate.Helpers
{
    public static partial class ExceptionHelpers
    {
        /// <summary>
        /// Gets the innermost exception of the thrown exception
        /// </summary>
        /// <param name="ex">The thrown exception</param>
        /// <returns>The innermost exception</returns>
        public static Exception GetInnermostException(this Exception ex)
        {
            var actualEx = ex;

            while (actualEx != null)
            {
                actualEx = actualEx.InnerException;
                if (actualEx != null)
                    ex = actualEx;
            }
            return ex;
        }
    }
}

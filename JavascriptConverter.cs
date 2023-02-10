using System;

namespace Penguin.Converters.DateTime
{
    /// <summary>
    /// Utility for convertime DateTime into a format compatible with JS
    /// </summary>
    public static class JavascriptConverter
    {
        #region Methods

        /// <summary>
        /// Converts a DateTime to UTC long
        /// </summary>
        /// <param name="from">The DateTime to convert</param>
        /// <returns>The long representation of the UTC</returns>
        public static long AsLocal(System.DateTime from)
        {
            System.DateTime now = System.DateTime.Now;

            TimeSpan diff = now - now.ToUniversalTime();

            return Convert(from - diff);
        }

        /// <summary>
        /// Converts a DateTime into a (JavaScript parsable) Int64.
        /// </summary>
        /// <param name="from">The DateTime to convert from</param>
        /// <returns>An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</returns>
        public static long Convert(System.DateTime from)
        {
            return System.Convert.ToInt64((from - _jan1st1970).TotalMilliseconds);
        }

        /// <summary>
        /// Converts a (JavaScript parsable) Int64 into a DateTime.
        /// </summary>
        /// <param name="from">An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</param>
        /// <returns>The date as a DateTime</returns>
        public static System.DateTime Convert(long from)
        {
            return _jan1st1970.AddMilliseconds(from);
        }

        #endregion Methods

        #region Fields

        //
        private static readonly System.DateTime _jan1st1970 = new(1970, 1, 1);

        #endregion Fields
    }
}
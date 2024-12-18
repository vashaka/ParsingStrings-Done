﻿using System;

namespace ParsingStrings
{
    public static class BooleanParser
    {
        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its Boolean equivalent.
        /// </summary>
        /// <param name="str">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains true if value is equal to <see cref="bool.TrueString"/> or false if value is equal to <see cref="bool.FalseString"/>. If the conversion failed, contains false.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseBoolean(string str, out bool result)
        {
            if (string.IsNullOrEmpty(str))
            {
                result = false;
                return false;
            }

            if (str.Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                return true;
            }
            else if (str.Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase))
            {
                result = false;
                return true;
            }

            result = false;
            return false;
        }

        /// <summary>
        /// Converts the specified string representation of a logical value to its Boolean equivalent.
        /// </summary>
        /// <param name="str">A string containing the value to convert.</param>
        /// <returns>true if value is equivalent to <see cref="bool.TrueString"/>; false if value is equivalent to <see cref="bool.FalseString"/>.</returns>
        public static bool ParseBoolean(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (str.Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return false;
        }
    }
}

using System;

namespace ParsingStrings
{
    public static class NumberParser
    {
        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseInteger(string str, out int result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str)) return false;
            return int.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns minus one.</returns>
        public static int ParseInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            // If the string is empty or contains only whitespace, return 0
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            // Try parsing the string as an integer
            if (int.TryParse(str, out int result))
            {
                // Check if the number is within the valid range for an int
                if (result < int.MinValue || result > int.MaxValue)
                {
                    return -1; // Outside the valid range for int
                }
                return result;
            }

            // Return -1 for any invalid input (e.g., non-numeric strings or out-of-range numbers)
            return -1;
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 32-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedInteger(string str, out uint result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return uint.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string representing the number to convert.</param>
        /// <returns>A 32-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of unsigned int. If an overflow error occurs returns maximum value of unsigned int.</returns>
        public static uint ParseUnsignedInteger(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                // Handle empty or whitespace-only strings
                return uint.MaxValue;  // Or another value depending on your requirement
            }

            // Handle negative numbers explicitly
            if (str.StartsWith("-"))
            {
                return uint.MaxValue;  // Return uint.MaxValue for negative input
            }

            if (ulong.TryParse(str, out ulong result))
            {
                if (result > uint.MaxValue)
                {
                    return uint.MaxValue;  // Return uint.MaxValue if overflow
                }

                return (uint)result;
            }

            throw new FormatException("Input string represents a number outside the valid range for an unsigned integer.");
        }


        /// <summary>
        /// Tries to convert the string representation of a number to its Byte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the Byte value equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseByte(string str, out byte result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return byte.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its Byte equivalent.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <returns>A byte value that is equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns maximum value of byte. If an overflow error occurs returns minimum value of byte.</returns>
        public static byte ParseByte(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return 255;
            }

            if (byte.TryParse(str, out byte result))
            {
                return result;
            }

            if (int.TryParse(str, out int intResult) && (intResult < 0 || intResult > 255))
            {
                return 0;
            }

            return 255;
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its SByte equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the 8-bit signed integer value that is equivalent to the number contained in <see cref="str"/> if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TrySignedByte(string str, out sbyte result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return sbyte.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 8-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents a number to convert.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number contained in the <see cref="str"/> parameter. If a formatting error occurs returns maximum value of signed byte.</returns>
        public static sbyte ParseSignedByte(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return sbyte.MaxValue;
            }

            if (sbyte.TryParse(str, out sbyte result))
            {
                return result;
            }

            throw new OverflowException("Input string represents a number outside the valid range for a signed byte.");
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit signed integer value equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseShort(string str, out short result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return short.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 16-bit signed integer equivalent to the number contained in <see cref="str"/>. If an overflow error occurs returns maximum value of short.</returns>
        public static short ParseShort(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new FormatException("Input string is empty or contains only whitespace.");
            }

            if (short.TryParse(str, out short result))
            {
                return result;
            }

            throw new FormatException("Input string is not in a valid format.");
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value that is equivalent to the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedShort(string str, out ushort result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return ushort.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 16-bit unsigned integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns zero. If an overflow error occurs returns maximum value of unsigned short.</returns>
        public static ushort ParseUnsignedShort(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            if (str.StartsWith("-"))
            {
                return ushort.MaxValue;
            }

            if (long.TryParse(str, out long parsedValue) && parsedValue > ushort.MaxValue)
            {
                return ushort.MaxValue;
            }

            if (ushort.TryParse(str, out ushort result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the number contained in <see cref="str"/>, if the conversion succeeded, or zero if the conversion failed. </param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseLong(string str, out long result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(str)) return false;

            return long.TryParse(str, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="str">A string containing a number to convert.</param>
        /// <returns>A 64-bit signed integer equivalent to the number contained in <see cref="str"/>. If a formatting error occurs returns minimum value of long. If an overflow error occurs returns minus one.</returns>
        public static long ParseLong(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return long.MinValue;
            }

            if (long.TryParse(str, out long result))
            {
                return result;
            }

            if (decimal.TryParse(str, out decimal decimalResult))
            {
                if (decimalResult > long.MaxValue || decimalResult < long.MinValue)
                {
                    return -1;
                }
            }

            return long.MinValue;
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value that is equivalent to the number contained in <see cref=""/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if <see cref="str"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParseUnsignedLong(string str, out ulong result)
        {
            if (string.IsNullOrEmpty(str))
            {
                result = 0;
                return false;
            }

            bool success = ulong.TryParse(str, out result);

            return success;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="str">A string that represents the number to convert.</param>
        /// <returns>A 64-bit unsigned integer equivalent to the number contained in <see cref="str"/>.</returns>
        public static ulong ParseUnsignedLong(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Input string cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new FormatException("Input string is empty or contains only whitespace.");
            }

            // Handle negative values explicitly
            if (str.StartsWith("-"))
            {
                throw new OverflowException("Negative numbers are not allowed for unsigned long.");
            }

            if (ulong.TryParse(str, out ulong result))
            {
                // Check for overflow if the number is larger than ulong.MaxValue
                if (result > ulong.MaxValue)
                {
                    throw new OverflowException("Input string represents a number larger than the maximum allowed for unsigned long.");
                }

                return result;
            }

            throw new FormatException("Invalid format for unsigned long.");
        }
    }
}

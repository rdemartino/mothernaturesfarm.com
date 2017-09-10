using System.Text.RegularExpressions;

namespace mothernaturesfarm.web.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the string is a valid numeric value
        /// </summary>
        /// <param name="str"></param>
        public static bool IsNumeric(this string str)
        {
            return (Regex.IsMatch(str, @"^[0-9]+$"));
        }
        /// <summary>
        /// Returns true if the string value is a valid email format
        /// </summary>
        /// <param name="str"></param>
        public static bool  IsValidEmail(this string str)
        {
            return Regex.IsMatch(str,
                @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}
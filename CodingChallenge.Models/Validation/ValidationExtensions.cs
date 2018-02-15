using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodingChallenge.Models.Validation
{
    public static class ValidationExtensions
    {
        /// <summary>         /// Throws a standardized ArgumentNullException if null or an empty string.         /// </summary>         /// <param name="paramName">Name of the parameter or field.</param>         /// <exception cref="ArgumentNullException"></exception>         public static void ThrowIfNullOrEmpty(this string value, string paramName)         {             if (String.IsNullOrEmpty(value))             {                 throw new ArgumentNullException(nameof(paramName), "Value must not be null or empty.");             }         }

        /// <summary>
        /// Throws a standardized ArgumentNullException if the object is null.
        /// </summary>
        /// <param name="paramName">Name of the parameter or field.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNullOrEmpty(this object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(paramName), "Value must not be null or empty.");
            }
        }

        public static List<string> GetStringConstants(this Type value) 
        {
            var values = value.GetFields(BindingFlags.Static | BindingFlags.Public)
                                 .Where(x => x.IsLiteral && !x.IsInitOnly)
                                 .Select(x => x.GetValue(null)).Cast<string>();

            return values.ToList();
        }

        public static string GetStringConstantValuesFormatted(Type enumType)
        {
            string output = "";

            foreach (string value in enumType.GetStringConstants())
            {
                output = output + value + ", ";
            }

            return output.TrimEnd(',', ' ');
        }
    }
}
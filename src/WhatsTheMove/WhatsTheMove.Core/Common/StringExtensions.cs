using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Enums;

namespace WhatsTheMove.Core.Common
{
    public static class StringExtensions
    {

        /// <summary>
        /// Converts an ienumerable of strings to a comma separated value
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ToCSV(this IEnumerable<string> values) => string.Join(",", values);

        /// <summary>
        /// Returns string representation of a preference
        /// </summary>
        /// <param name="preference"></param>
        /// <returns></returns>
        public static string ToPreferenceString(this Preference preference)
        {
            string preferenceString =                 
                $"{preference.ZipCode}, " +
                (preference.Distance != null ? $"Distance: {preference.Distance.ToNullString()}, " : string.Empty) +
                (preference.GroupSize != null ? $"Group Size: {preference.GroupSize.ToNullString()}, " : string.Empty) +
                (preference.IsFoodRequested != null ? (bool)preference.IsFoodRequested ? "Food, " : string.Empty : string.Empty) +
                (preference.IsDrinksRequested != null ? (bool)preference.IsDrinksRequested ? "Drinks, " : string.Empty : string.Empty) +
                (preference.EnergyLevel != null ? $"{(EnergyLevel)((int)preference.EnergyLevel)} Energy, " : string.Empty) +
                (preference.Budget != null ? $"{(Budget)((int)preference.Budget)}, " : string.Empty) +
                (preference.TimeOfDay != null ? $"{(TimeOfDay)((int)preference.TimeOfDay)}, " : string.Empty) +
                (preference.DressCode != null ? $"Dress Code: {(DressCode)((int)preference.DressCode)}" : string.Empty);

            preferenceString = preferenceString.Trim();            

            if (preferenceString[preferenceString.Length - 1] == ',')
                preferenceString = preferenceString.Substring(0, preferenceString.Length - 1);

            return preferenceString;
        }

        /// <summary>
        /// Converts the nullable object to a string. returns empty if null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNullString(this object? value)
        {
            if (value == null) return string.Empty;
            else return value.ToString();
        }

        /// <summary>
        /// Converts the string to 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string ToEnumString(this string value, Type enumType)
        {            
            if (value == null) return string.Empty;
            else return $"{Enum.Parse(enumType, (string)value)}";
        }
    }
}

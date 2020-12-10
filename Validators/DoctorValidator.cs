using System.Text.RegularExpressions;

namespace Validators
{
    public static class DoctorValidator
    {
        /// <summary>
        /// Checks that the provided name could get a result.
        /// </summary>
        /// <param name="name">The name to check.</param>
        /// <returns>True if the name could get a result, false if otherwise.</returns>
        public static bool ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            return Regex.IsMatch(name, @"^[a-zA-Z]+ [a-zA-Z]+$");
        }

        /// <summary>
        /// Checks that the provided year could get a result.
        /// </summary>
        /// <param name="year">The year to check.</param>
        /// <returns>True if the year could get a result, false if otherwise.</returns>
        public static bool ValidYear(int year)
        {
            return (year > 1962) && (year < 2050);
        }
    }
}

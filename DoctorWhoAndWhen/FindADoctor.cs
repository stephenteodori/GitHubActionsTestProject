using System;
using System.Collections.Generic;
using System.Linq;
using Validators;

namespace DoctorWhoAndWhen
{
    /// <summary>
    /// Find information about actors who portrayed the Doctor.
    /// </summary>
    public class FindADoctor
    {
        /// <summary>
        /// Stores data for all the doctors.
        /// </summary>
        private readonly List<Doctor> _theDoctors = new List<Doctor>();

        /// <summary>
        /// The singleton instance for this class.
        /// </summary>
        private static FindADoctor _instance;

        /// <summary>
        /// Get the singleton instance for this class.
        /// </summary>
        public static FindADoctor Instance => _instance ?? (_instance = new FindADoctor());

        /// <summary>
        /// Creates a new instance of <see cref="FindADoctor"/>.
        /// </summary>
        private FindADoctor()
        {
            // TODO: Add more doctors
            // TODO: Move this data into a resource file for easier updates
            _theDoctors.Add(new Doctor("Christopher Eccleston",
                new HashSet<int> {2005}));
            _theDoctors.Add(new Doctor("David Tennant",
                new HashSet<int> {2005, 2006, 2007, 2008, 2009, 2010}));
        }

        /// <summary>
        /// Gets the doctors who portrayed the doctor in a given year.
        /// </summary>
        /// <param name="year">The year to lookup doctors by.</param>
        /// <returns>The doctors who portrayed the doctor in a given year.</returns>
        public List<string> GetDoctorsForYear(int year)
        {
            if (!DoctorValidator.ValidYear(year)) return new List<string>();

            return _theDoctors.Where(doc => doc.Years.Contains(year)).Select(doc => doc.ToString()).ToList();
        }

        /// <summary>
        /// Finds information about a given Doctor by actor name.
        /// </summary>
        /// <param name="name">The actor's name to look up.</param>
        /// <returns>Information about the doctor as portrayed by the given actor.</returns>
        public string GetDoctorByName(string name)
        {
            if (!DoctorValidator.ValidName(name)) return null;

            return _theDoctors.Find(doc => doc.ActorName.Equals(name, StringComparison.CurrentCultureIgnoreCase))?.ToString();
        }
    }
}

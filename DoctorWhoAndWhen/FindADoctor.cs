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
        public static FindADoctor Instance => _instance ??= new FindADoctor();

        /// <summary>
        /// Creates a new instance of <see cref="FindADoctor"/>.
        /// </summary>
        private FindADoctor()
        {
            InitializeDoctors();
        }

        /// <summary>
        /// Gets the doctors who portrayed the doctor in a given year.
        /// </summary>
        /// <param name="year">The year to lookup doctors by.</param>
        /// <returns>The doctors who portrayed the doctor in a given year.</returns>
        public IEnumerable<Doctor> GetDoctorsForYear(int year)
        {
            if (!DoctorValidator.ValidYear(year)) return new List<Doctor>();

            return _theDoctors.Where(doc => doc.Years.Contains(year));
        }

        /// <summary>
        /// Finds information about a given Doctor by actor name.
        /// </summary>
        /// <param name="name">The actor's name to look up.</param>
        /// <returns>Information about the doctor as portrayed by the given actor.</returns>
        public Doctor GetDoctorByName(string name)
        {
            // TODO: Add partial name matching.
            if (!DoctorValidator.ValidName(name)) return null;

            return _theDoctors.Find(doc => doc.ActorName.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Adds doctors into the list.
        /// </summary>
        private void InitializeDoctors()
        {
            // TODO: Add more doctors and years they temporarily played the doctor.
            // TODO: Move this data into a resource file for easier updates.
            _theDoctors.Add(new Doctor("William Hartnell",
                new HashSet<int> {1963, 1964, 1965, 1966}));
            _theDoctors.Add(new Doctor("Patrick Troughton",
                new HashSet<int> {1966, 1967, 1968, 1969}));
            _theDoctors.Add(new Doctor("Jon Pertwee",
                new HashSet<int> {1970, 1971, 1972, 1973, 1974}));
            _theDoctors.Add(new Doctor("Tom Baker",
                new HashSet<int> {1974, 1975, 1976, 1977, 1978, 1979, 1980, 1981}));
            _theDoctors.Add(new Doctor("Peter Davison",
                new HashSet<int> {1982, 1983, 1984}));
            _theDoctors.Add(new Doctor("Colin Baker",
                new HashSet<int> {1984, 1985, 1986}));
            _theDoctors.Add(new Doctor("Sylvester McCoy",
                new HashSet<int> {1987, 1988, 1989}));
            _theDoctors.Add(new Doctor("Paul McGann",
                new HashSet<int> {1996}));
            _theDoctors.Add(new Doctor("Christopher Eccleston",
                new HashSet<int> {2005}));
            _theDoctors.Add(new Doctor("David Tennant",
                new HashSet<int> {2005, 2006, 2007, 2008, 2009, 2010}));
            _theDoctors.Add(new Doctor("Matt Smith",
                new HashSet<int> {2010, 2011, 2012, 2013}));
            _theDoctors.Add(new Doctor("Peter Capaldi",
                new HashSet<int> {2014, 2015, 2016, 2017}));
            _theDoctors.Add(new Doctor("Jodie Whittaker",
                new HashSet<int> {2018, 2019, 2020}));
        }
    }
}

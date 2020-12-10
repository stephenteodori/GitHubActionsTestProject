using System.Collections.Generic;
using System.Linq;
using DoctorWhoAndWhen;
using Xunit;

namespace DoctorWhoAndWhenTests.FindADoctorTests
{
    public class DoctorByYearTests
    {
        [Fact]
        public void GetDoctorByYear_ReturnsEmptyListIfYearIsNotOnList()
        {
            Assert.Empty(FindADoctor.Instance.GetDoctorsForYear(1000));
            Assert.Empty(FindADoctor.Instance.GetDoctorsForYear(2000));
            Assert.Empty(FindADoctor.Instance.GetDoctorsForYear(2030));
        }

        [Fact]
        public void GetDoctorByYear_ReturnsEmptyListForImpossibleYears()
        {
            Assert.Empty(FindADoctor.Instance.GetDoctorsForYear(-1000));
            Assert.Empty(FindADoctor.Instance.GetDoctorsForYear(500000));
        }

        [Fact]
        public void GetDoctorByYear_ReturnsSingleEntryForSingleDoctorFound()
        {
            const int yearToCheck = 2007;
            List<Doctor> results = FindADoctor.Instance.GetDoctorsForYear(yearToCheck).ToList();
            Assert.Single(results);
            Assert.Contains(yearToCheck, results[0].Years);
        }

        [Fact]
        public void GetDoctorByYear_ReturnsMultipleDoctorsIfMultipleAreFound()
        {
            const int yearToCheck = 2005;
            List<Doctor> results = FindADoctor.Instance.GetDoctorsForYear(yearToCheck).ToList();
            Assert.True(results.Count > 1);

            foreach (Doctor result in results)
            {
                Assert.Contains(yearToCheck, result.Years);
            }
        }
    }
}
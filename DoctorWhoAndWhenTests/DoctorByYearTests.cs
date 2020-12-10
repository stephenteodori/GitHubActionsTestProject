using System.Collections.Generic;
using DoctorWhoAndWhen;
using Xunit;

namespace DoctorWhoAndWhenTests
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
            List<string> results = FindADoctor.Instance.GetDoctorsForYear(yearToCheck);
            Assert.Single(results);
            Assert.Contains(yearToCheck.ToString(), results[0]);
            Assert.Matches(@"\w+ - \([0-9, ]+\)", results[0]);
        }

        [Fact]
        public void GetDoctorByYear_ReturnsMultipleDoctorsIfMultipleAreFound()
        {
            const int yearToCheck = 2005;
            List<string> results = FindADoctor.Instance.GetDoctorsForYear(yearToCheck);
            Assert.True(results.Count > 1);

            foreach (string result in results)
            {
                Assert.Contains(yearToCheck.ToString(), result);
                Assert.Matches(@"\w+ - \([0-9, ]+\)", result);
            }
        }
    }
}
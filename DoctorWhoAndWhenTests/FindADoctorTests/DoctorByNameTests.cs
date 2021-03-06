using Xunit;
using DoctorWhoAndWhen;

namespace DoctorWhoAndWhenTests.FindADoctorTests
{
    public class DoctorByNameTests
    {
        [Fact]
        public void GetDoctorByName_ReturnsNullForNullName()
        {
            Assert.Null(FindADoctor.Instance.GetDoctorByName(null));
        }

        [Fact]
        public void GetDoctorByName_ReturnsNullForEmptyName()
        {
            Assert.Null(FindADoctor.Instance.GetDoctorByName(string.Empty));
        }

        [Fact]
        public void GetDoctorByName_ReturnsNullIfNoMatchFound()
        {
            Assert.Null(FindADoctor.Instance.GetDoctorByName("John Smith"));
            Assert.Null(FindADoctor.Instance.GetDoctorByName("Rose Tyler"));
            Assert.Null(FindADoctor.Instance.GetDoctorByName("Doctor"));
        }

        [Fact]
        public void GetDoctorByName_ReturnsNullIfInvalidCharactersAreSubmitted()
        {
            Assert.Null(FindADoctor.Instance.GetDoctorByName("David Ten.nant"));
            Assert.Null(FindADoctor.Instance.GetDoctorByName("David *$&@(<>"));
        }

        [Fact]
        public void GetDoctorByName_GetsDoctorInformation()
        {
            const string nameToTry = "David Tennant";
            Doctor result = FindADoctor.Instance.GetDoctorByName(nameToTry);
            Assert.NotNull(result);
            Assert.Equal(nameToTry, result.ActorName);
        }
    }
}

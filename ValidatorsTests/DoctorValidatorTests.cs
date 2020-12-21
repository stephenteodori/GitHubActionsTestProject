using Validators;
using Xunit;

namespace ValidatorsTests
{
    public class DoctorValidatorTests
    {
        #region Valid Name

        [Fact]
        public void ValidName_ReturnsFalseFromNullInput()
        {
            Assert.False(DoctorValidator.ValidName(null));
        }

        [Fact]
        public void ValidName_ReturnsFalseFromEmptyString()
        {
            Assert.False(DoctorValidator.ValidName(string.Empty));
        }

        [Fact]
        public void ValidName_ReturnsFalseFromInvalidCharacters()
        {
            Assert.False(DoctorValidator.ValidName("Doc.tor W&*ho"));
        }

        [Fact]
        public void ValidName_ReturnsFalseForSingleNames()
        {
            Assert.False(DoctorValidator.ValidName("Frank"));
        }

        [Fact]
        public void ValidName_ReturnsFalseForMoreThanTwoNames()
        {
            Assert.False(DoctorValidator.ValidName("Frank Smith Halloway"));
            Assert.False(DoctorValidator.ValidName("John Jacob Jingleheimer Smith"));
        }

        [Fact]
        public void ValidName_ReturnsTrueForValidNames()
        {
            Assert.True(DoctorValidator.ValidName("John Smith"));
            Assert.True(DoctorValidator.ValidName("Rose Tyler"));
            Assert.True(DoctorValidator.ValidName("Christopher Eccleston"));
            Assert.False(DoctorValidator.ValidName("Doctor"));
        }

        #endregion Valid Name

        #region Valid Year

        [Fact]
        public void ValidYear_ReturnsFalseForYearsBeforeShowStart()
        {
            Assert.False(DoctorValidator.ValidYear(1962));
        }

        [Fact]
        public void ValidYear_ReturnsFalseForYearsSignificantlyAfterCurrentYear()
        {
            Assert.False(DoctorValidator.ValidYear(2050));
        }

        [Fact]
        public void ValidYear_ReturnsTrueForValidYears()
        {
            Assert.True(DoctorValidator.ValidYear(1963));
            Assert.True(DoctorValidator.ValidYear(1970));
            Assert.True(DoctorValidator.ValidYear(1995));
            Assert.True(DoctorValidator.ValidYear(2003));
            Assert.True(DoctorValidator.ValidYear(2011));
            Assert.True(DoctorValidator.ValidYear(2049));
        }

        #endregion Valid Year
    }
}

using System.Collections.Generic;
using DoctorWhoAndWhen;
using Xunit;

namespace DoctorWhoAndWhenTests
{
    public class DoctorTests
    {
        [Fact]
        public void ToString_OutputsExpectedFormat()
        {
            Assert.Matches(@"\w+ - \([0-9, ]+\)",
                new Doctor("Jodie Whittaker", new HashSet<int> {2018, 2019, 2020}).ToString());
        }
    }
}
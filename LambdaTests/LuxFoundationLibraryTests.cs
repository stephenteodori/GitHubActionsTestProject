using Xunit;
using Amazon.Lambda.TestUtilities;
using Lambda;

namespace LambdaTests
{
    public class LuxFoundationLibraryTests
    {
        [Fact]
        public void CourtesyNode_ReturnsDoctorInfoFromName()
        {
            LuxFoundationLibrary luxFoundationLibrary = new LuxFoundationLibrary();
            TestLambdaContext context = new TestLambdaContext();

            const string doctorName = "Paul McGann";

            Hypercube testRequest = new Hypercube()
            {
                Operation = OperationType.GetDoctorByName,
                OperationInput = doctorName
            };
            string requestOutput = luxFoundationLibrary.CourtesyNode(testRequest, context);

            Assert.Contains(doctorName, requestOutput);
        }

        [Fact]
        public void CourtesyNode_ReturnsDoctorsForGivenYear()
        {
            LuxFoundationLibrary luxFoundationLibrary = new LuxFoundationLibrary();
            TestLambdaContext context = new TestLambdaContext();

            const string year = "1996";
            const string expectedDoctor = "Paul McGann";

            Hypercube testRequest = new Hypercube()
            {
                Operation = OperationType.GetDoctorsForYear,
                OperationInput = year
            };
            string requestOutput = luxFoundationLibrary.CourtesyNode(testRequest, context);

            Assert.Contains(expectedDoctor, requestOutput);
        }
    }
}

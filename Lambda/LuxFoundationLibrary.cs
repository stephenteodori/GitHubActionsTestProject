using System;
using System.Text.Json;
using Amazon.Lambda.Core;
using DoctorWhoAndWhen;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Lambda
{
    /// <summary>
    /// Manages incoming requests for data.
    /// </summary>
    public class LuxFoundationLibrary
    {
        /// <summary>
        /// Entry point for incoming requests.
        /// </summary>
        /// <param name="request">The data submitted with the request.</param>
        /// <param name="context">Context for the lambda operation.</param>
        /// <returns>The result of the requested operation.</returns>
        public string CourtesyNode(Hypercube request, ILambdaContext context)
        {
            switch (request.Operation)
            {
                case OperationType.GetDoctorByName:
                    return JsonSerializer.Serialize(FindADoctor.Instance.GetDoctorByName(request.OperationInput));
                case OperationType.GetDoctorsForYear:
                    return JsonSerializer.Serialize(
                        FindADoctor.Instance.GetDoctorsForYear(Convert.ToInt32(request.OperationInput)));
                default:
                    throw new Exception(
                        "The submitted operation does not exist. Please check that your input is not formatted for a future API.");
            }
        }
    }
}

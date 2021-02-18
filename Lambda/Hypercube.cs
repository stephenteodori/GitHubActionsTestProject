namespace Lambda
{
    /// <summary>
    /// Formatted request data.
    /// </summary>
    public class Hypercube
    {
        /// <summary>
        /// The operation to perform.
        /// </summary>
        public OperationType Operation { get;set; }

        /// <summary>
        /// The input to use for the operation.
        /// </summary>
        public string OperationInput { get; set; }
    }
}

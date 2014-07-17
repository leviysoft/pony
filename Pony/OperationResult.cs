namespace Pony
{
    public class OperationResult
    {
        public static OperationResult<T> Produce<T>(OperationStatus status, T result) where T : class
        {
            return new OperationResult<T>(status, result);
        }
    }

    public class OperationResult<T> where T : class
    {
        public T Result { get; private set; }
        public OperationStatus Status { get; private set; }

        public OperationResult(OperationStatus status, T result)
        {
            Result = result;
            Status = status;
        }
    }
}

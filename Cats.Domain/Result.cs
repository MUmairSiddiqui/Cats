namespace Cats.Domain
{
    public class Result<T>
        where T : class
    {
        public T Value { get; private set; }
        
        public Result(T value)
        {
            Value = value;
        }

        public bool IsSuccess => Value != null;
    }
}

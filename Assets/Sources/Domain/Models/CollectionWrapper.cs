namespace Sources.Domain.Models
{
    public class CollectionWrapper<T>
    {
        public CollectionWrapper(T[] collection)
        {
            Collection = collection;
        }

        public T[] Collection { get; }
    }
}
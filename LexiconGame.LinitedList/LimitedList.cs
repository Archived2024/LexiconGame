namespace LexiconGame.LinitedList
{
    public class LimitedList<T>
    {
        private readonly int capacity;
        private List<T> list;

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
            list = new List<T>(this.capacity);
        }

        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (IsFull) return false;
            list.Add(item); return true;
        }
    }
}

namespace LexiconGame.LinitedList
{
    public class LimitedList<T>
    {
        private readonly int capacity;
        private List<T> list;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
        }
    }
}

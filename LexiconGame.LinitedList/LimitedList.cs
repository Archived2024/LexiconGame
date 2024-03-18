using System.Collections;

namespace LexiconGame.LinitedList
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private readonly int capacity;
        protected List<T> list;

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public T this[int index] => list[index];
        //{
        //    get => list[index];
        //    set => list[index] = value;
        //}

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
            list = new List<T>(this.capacity);
        }

        public virtual bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (IsFull) return false;
            list.Add(item); return true;
        }

        public void Print(Action<T> action)
        {
            //list.ForEach(action);
            //list.ForEach(x => action(x));
            list.ForEach(x => action?.Invoke(x));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}

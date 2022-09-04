namespace AccManagerData.Model
{
    public class Pagination<T>
    {
        private int page;
        private long count;
        private int pageSize;
        public Pagination(IEnumerable<T> values, long count, int page, int pageSize)
        {
            Subset.AddRange(values);
            this.count = count;
            this.page = page;
            this.pageSize = pageSize;
        }

        protected readonly List<T> Subset = new List<T>();
        public T this[int index] => Subset[index];
        public virtual int PageSize => pageSize;
        public virtual int Page => page;
        public virtual long Count => count;
    }
}

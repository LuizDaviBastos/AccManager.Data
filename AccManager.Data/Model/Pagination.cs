using System.Collections;

namespace AccManagerData.Model
{
    public class Pagination<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private int currentPage;
        private int totalPage;
        private int pageSize;
        public Pagination(IEnumerable<T> values, int totalPage, int currentPage, int pageSize)
        {
            Subset.AddRange(values);
            this.totalPage = totalPage;
            this.currentPage = currentPage;
            this.pageSize = pageSize;
        }

        protected readonly List<T> Subset = new List<T>();
        public T this[int index] => Subset[index];
        public virtual int PageSize => pageSize;
        public virtual int Page => currentPage;
        public virtual int TotalPage => totalPage;

        public int Count => Subset.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Subset.GetEnumerator();
        }
    }
}

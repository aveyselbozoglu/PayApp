using System;
using System.Collections.Generic;
using System.Linq;

namespace Payer
{
    public class ListPagination<T> : List<T>
    {

        public int PageIndex { get;private set; }
        public int TotalPages { get;private set; }

        public bool IsPreviousPageAvailable() => PageIndex > 1;

        public bool IsNextPageAvailable() => PageIndex < TotalPages;


        public static ListPagination<T> Create(List<T> source,int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1 )* pageSize).Take(pageSize).ToList();
            return new ListPagination<T>(items,count,pageIndex,pageSize);

        }

        public ListPagination(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

    }
}
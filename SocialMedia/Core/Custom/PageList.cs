namespace SocialMedia.Core.Custom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PageList<T>: List<T>
    {
        public int Current { get; set; }

        public int TotalPage { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasPreviusPage => Current > 1;

        public bool HasNextPage => Current < TotalPage;

        public int? NextPageNumber => HasNextPage ? Current + 1 : (int?)null;

        public int? PreviusPageNumber => HasPreviusPage ? Current - 1 : (int?)null;

        public PageList(List<T> list, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            Current = pageNumber;
            TotalPage = (int)Math.Ceiling(count/(double)pageSize);
            AddRange(list);
        }

        public static PageList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize) 
        {
            return new PageList<T>(source.Skip((pageNumber-1)* pageSize).Take(pageSize).ToList(), 
                source.Count(), pageNumber, pageSize);
        }
    }
}
using SGWebAPI.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Helper
{
    public static class ListPager
    {
        public static int CalculatePageStartRecord(int pageSize, int pageNo) => ((Math.Max(1, pageNo) - 1) * Math.Max(0, pageSize)) + 1;

        public static int CalculateTotalPages(int pageSize, int totalCount)
        {
            var pages = totalCount / pageSize;
            if (totalCount % pageSize > 0)
            {
                ++pages;
            }

            return Math.Max(1, pages);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> query, int pageSize, int pageNo) => query.AsQueryable().ToPagedList(pageSize, pageNo);

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, int pageSize, int pageNo)
        {
            var totalCount = query.Count();
            var (pagedQuery, pagingParameters) = query.PageIt(totalCount, pageSize, pageNo);
            return pagedQuery.ToList().ToPagedList(pagingParameters);
        }

        public static PagedList<T> ToPagedList<T>(this IList<T> list, PagingParameters pagingParameters) => new PagedList<T>(list, pagingParameters.TotalCount, pagingParameters.PageSize, pagingParameters.TotalPages, pagingParameters.PageNo, pagingParameters.StartRecord);

        private static (IQueryable<T> pagedQuery, PagingParameters pagingParameters) PageIt<T>(this IQueryable<T> query, int totalCount, int pageSize, int pageNo)
        {
            var totalPages = CalculateTotalPages(pageSize, totalCount);
            var startRecord = CalculatePageStartRecord(pageSize, pageNo);
            var skipCount = (pageNo - 1) * pageSize;
            query = query.Skip(skipCount).Take(pageSize);
            return (query, new PagingParameters(totalCount, pageSize, totalPages, pageNo, startRecord));
        }
    }

    public class PagingParameters
    {
        public int TotalCount, PageSize, TotalPages, PageNo, StartRecord;

        public PagingParameters(int totalCount, int pageSize, int totalPages, int pageNo, int startRecord)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = totalPages;
            PageNo = pageNo;
            StartRecord = startRecord;
        }
    }
}

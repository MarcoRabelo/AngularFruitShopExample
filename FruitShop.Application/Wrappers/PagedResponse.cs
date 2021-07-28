using FruitShop.Domain.Models;
using System;

namespace FruitShop.Application.Wrappers
{
    public class PagedResponse<TEntity> : Response<TEntity>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public Uri FirstPage { get; set; }

        public Uri LastPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        //TODO
        public Uri NextPage { get; set; }

        //TODO
        public Uri PreviousPage { get; set; }

        public PagedResponse(TEntity data, PageInfo pageInfo)
        {
            PageNumber = pageInfo.PageNumber;
            PageSize = pageInfo.PageSize;
            TotalPages = pageInfo.TotalPages;
            TotalRecords = pageInfo.TotalRecords;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}

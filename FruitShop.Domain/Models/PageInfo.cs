namespace FruitShop.Domain.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
    }
}

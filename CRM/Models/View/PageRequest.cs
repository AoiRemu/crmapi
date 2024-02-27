namespace CRM.Models.View
{
    public class PageRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }

    public class PageResponse<T> where T : class
    {
        public int Total { get; set; }

        public List<T> Data { get; set; } = new List<T>();
    }
}

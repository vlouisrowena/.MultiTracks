namespace MultiTracksAPI.Models
{
    public class PageParams
    {

        const int maxPageSize = 30; //max 30 songs per page
        public int pageNumber { get; set; } = 1;
        private int _pageSize = 10;  
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}

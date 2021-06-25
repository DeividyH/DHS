using DHS.Domain.Core.Interfaces.Pages;

namespace DHS.Domain.Core.Services.Dtos.Pages
{
    public class GetAllFilteredPagination : IGetAllFilteredPagination
    {
        public PagedResultRequestDto PagedRequest { get; set; }
        public string Sort { get; set; }
        public bool IsAsc { get; set; }
        public string Search { get; set; }
    }
}

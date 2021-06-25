using DHS.Domain.Core.Services.Dtos.Pages;

namespace DHS.Domain.Core.Interfaces.Pages
{
    public interface IGetAllFilteredPagination
    {
        PagedResultRequestDto PagedRequest { get; set; }
        string Sort { get; set; }
        bool IsAsc { get; set; }
        string Search { get; set; }
    }
}

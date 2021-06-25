using DHS.Domain.Core.Services.Dtos.Pages;

namespace DHS.Domain.Core.Interfaces.Filters
{
    public interface IFilterToSelectPickerDto
    {
        PagedResultRequestDto PagedRequest { get; set; }
        string Search { get; set; }
        string PrimeiroCampo { get; set; }
        string SegundoCampo { get; set; }
    }
}

using DHS.Domain.Core.Interfaces.Filters;
using DHS.Domain.Core.Services.Dtos.Pages;

namespace DHS.Domain.Core.Services.Dtos.Filters
{
    public class FilterToSelectPickerDto : IFilterToSelectPickerDto
    {
        public PagedResultRequestDto PagedRequest { get; set; }
        public string Search { get; set; }
        public string PrimeiroCampo { get; set; }
        public string SegundoCampo { get; set; }
    }
}

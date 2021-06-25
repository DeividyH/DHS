
using DHS.Application.Dtos.Users;
using DHS.Domain.Core.Services.Dtos.Pages;
using DHS.Domain.Entities.Users;
using DHS.Domain.Interfaces;

namespace DHS.Application.Interfaces.Users
{
    public interface IUserAppService : IDhsCrudAppService<User, UserDto, long, PagedResultRequestDto>
    {
    }
}

using DHS.Application.Dtos.Users;
using DHS.Application.Interfaces.Users;
using DHS.Domain.Core.Interfaces.Repositories;
using DHS.Domain.Core.Services.Dtos.Pages;
using DHS.Domain.Entities.Users;
using DHS.Domain.Services;

namespace DHS.Application.Services.Users
{
    public class UserAppService : DhsCrudAppService<User, UserDto, long, PagedResultRequestDto>, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;

        public UserAppService(IRepository<User, long> userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}

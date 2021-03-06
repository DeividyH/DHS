using DHS.Application.Dtos.Users;
using DHS.Application.Interfaces.Users;
using DHS.Domain.Core.Services.Dtos.Audit;
using DHS.Domain.Core.Services.Dtos.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DHS.Presentation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet("GetAll")]
        public async Task<PagedResultDto<UserDto>> GetAll()
        {
            var input = new PagedResultRequestDto();

            var processReturn = await _userAppService.GetAll(input);

            return processReturn;
        }

        [HttpGet("Get")]
        public async Task<UserDto> Get([FromQuery]EntityDto<long> input)
        {
            var processReturn = await _userAppService.Get(input);

            return processReturn;
        }

        [HttpPost("Create")]
        public async Task<UserDto> Create([FromQuery]UserDto input)
        {
            var processReturn = await _userAppService.Create(input);

            return processReturn;
        }

        [HttpPut("Update")] 
        public async Task<UserDto> Update([FromQuery]UserDto input)
        {
            var processReturn = await _userAppService.Update(input);

            return processReturn;
        }

        [HttpDelete("Delete")]
        public async Task Delete([FromQuery]EntityDto<long> input)
        {
            await _userAppService.Delete(input);
        }
    }
}

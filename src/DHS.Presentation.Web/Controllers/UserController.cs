using DHS.Application.Dtos.Users;
using DHS.Application.Interfaces.Users;
using DHS.Domain.Core.Services.Dtos.Lists;
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

        [HttpGet]
        public async Task GetAll()
        {
            var list = await _userAppService.GetAll(null);

        }
    }
}

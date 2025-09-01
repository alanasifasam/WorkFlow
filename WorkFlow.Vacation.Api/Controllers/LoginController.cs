using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Vacation.Application.Models;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Services;

namespace WorkFlow.Vacation.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("FirstAccess")]
        [AllowAnonymous]
        public async Task<IActionResult> FirstAccess([FromBody] FirstAccessInputModel input)
        {
            var model = new FirstAccessModel(input);
            var result = _loginService.FirstAccess(model);

            return Ok(result.Result);
        }



        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginInputModel input)
        {
            var loginModel = new LoginModel(input);
            var result = await _loginService.LoginAutentication(loginModel);

            return Ok(result);
        }

    }
}

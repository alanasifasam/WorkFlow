using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models;
using WorkFlow.Vacation.Core.Interfaces;

namespace WorkFlow.Vacation.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthService _authService;
        private readonly IFirstAccessRepository _firstAccessRepository;
        public LoginService(IAuthService authService, IFirstAccessRepository firstAccessRepository)
        {
            _authService = authService;
            _firstAccessRepository = firstAccessRepository;
        }

        public async Task<Guid> FirstAccess(FirstAccessModel firstAccess)
        {

            var passwordHash = _authService.ComputeSha256Hash(firstAccess.Password);
            var registro = firstAccess.ToEntity();
            registro.Password = passwordHash;
            var result = await _firstAccessRepository.CreatAccessAsync(registro);

            return result;
        }

        public async Task<LoginModel> LoginAutentication(LoginModel login)
        {

            var passwordHash = _authService.ComputeSha256Hash(login.Password);
            var entity = login.ToEntity();
            entity.Password = passwordHash;
            entity.Email = login.Email;
            entity = await _firstAccessRepository.GetFirstAccessAsync(entity);
            if (entity == null)
            {
                return null;
            }
            string role = "ADMIN";
            var token = _authService.GenerateJwtToken(entity.Email, role);
            login.Email = entity.Email;
            login.Token = token;

            return login;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models;

namespace WorkFlow.Vacation.Application.Services
{
    public interface ILoginService
    {
        Task<Guid> FirstAccess(FirstAccessModel firstAccess);

        Task<LoginModel> LoginAutentication(LoginModel login);
    }
}

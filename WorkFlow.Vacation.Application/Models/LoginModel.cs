using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Application.Models
{
    public class LoginModel
    {
        public LoginModel(LoginInputModel login)
        {
            Email = login.Email;
            Token = login.Token;
            Password = login.Password;

        }

        public FirstAccessEntity ToEntity() => new FirstAccessEntity(Email, Token, Password);

        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Application.Models
{
    public class FirstAccessModel
    {
        public FirstAccessModel(FirstAccessInputModel input)
        {
            UserName = input.UserName;
            Email = input.Email;
            Password = input.Password;


        }

        public FirstAccessEntity ToEntity() => new FirstAccessEntity(UserName, Email, Password);

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

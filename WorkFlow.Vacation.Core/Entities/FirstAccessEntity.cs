using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Vacation.Core.Entities
{
    public class FirstAccessEntity
    {
        public FirstAccessEntity(string userName, string email, string password)
        {
            Id = new Guid();
            UserName = userName;
            Email = email;
            Password = password;
        }

        public Guid Id { get; private set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

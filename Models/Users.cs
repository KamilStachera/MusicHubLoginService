using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHubLoginService.Models
{
    public class Users
    {
        //public User(string login, string password)
        //{
        //    Id = Guid.NewGuid();
        //    Login = login;
        //    Password = password;

        //}

        //[Key]
        //public Guid Id { get; }
        //public string Login { get; }
        //public string Password { get; }

        public Guid id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

    }
}

using MusicHubLoginService.Dto;
using MusicHubLoginService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHubLoginService.Services
{
    public interface ILoginService
    {
        Users CreateUser(string login, string password);
        string Login(LoginRequest request);
    }
}

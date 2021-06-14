using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicHubLoginService.Db;
using MusicHubLoginService.Dto;
using MusicHubLoginService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicHubLoginService.Services
{
    public class LoginService : ILoginService
    {

        private readonly UsersDbContext _userDbContext;
        private readonly IConfiguration _configuration;

        #region CTOR
        public LoginService(UsersDbContext usersDbContext, IConfiguration configuration)
        {
            _userDbContext = usersDbContext;
            _configuration = configuration;
        }
        #endregion CTOR

        #region PublicMethods

        public Users CreateUser(string login, string password)
        {
            CheckIfUserExists(login);

            var user = new Users { id = Guid.NewGuid(), login = login, password = password };
            _userDbContext.Add(user);
            _userDbContext.SaveChanges();

            return user;
        }

        public string Login(LoginRequest request)
        {
            var user = AuthenticateUser(request.Login, request.Password);
            return user != null ? CreateJwtForUser(user) : null;
        }

        #endregion PublicMethods

        #region PrivateMethods
        private void CheckIfUserExists(string login)
        {
            if (_userDbContext.Users.FirstOrDefault(user => user.login.Equals(login)) != null)
            {
                throw new DuplicateNameException("Login taken");
            }
        }

        private Users AuthenticateUser(string login, string password)
        {
            return _userDbContext.Users.FirstOrDefault(user => user.login.Equals(login) && user.password.Equals(password));
        }

        private string CreateJwtForUser(Users user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                CreateClaimsForUser(user),
                expires: DateTime.Now.AddMinutes(150),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static IEnumerable<Claim> CreateClaimsForUser(Users user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                new Claim("login", user.login)
            };
        }

        #endregion PrivateMethods
    }
}

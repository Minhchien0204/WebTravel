using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webtravel.Helpers;
using Webtravel.Models;

namespace Webtravel.Service
{
    public interface IUserService
    {
        Users Authenticate(string UserNames, string Passwords);
        IEnumerable<Users> GetAll();
        Users GetById(int Id);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private WebtravelContext _context;
        private List<Users> _users = new List<Users> { };
        private readonly AppSettings _appSettings;


        public UserService(WebtravelContext context)
        {
            _context = context;
        }
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
       
        public Users Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserNames == username && x.Passwords == password);

             // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString()),
                    new Claim(ClaimTypes.Role, user.Roles)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<Users> GetAll()
        {
            return _users.WithoutPassWords();
        }

        public Users GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.IdUser == id);
            return user.WithoutPassword();
        }

        public void Update(Users userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.IdUser);
            //kiem tra user
            if (user == null)
                throw new ApplicationException("khong tim thay user");

            if (userParam.IdUser != user.IdUser)
            {
                if (_context.Users.Any(x => x.IdUser == userParam.IdUser))
                    throw new ApplicationException("Username " + userParam + "is alrealy taken");
            }
            // update user
            else
            {
                user.UserNames = userParam.UserNames;
                user.Ngaysinh = userParam.Ngaysinh;
                user.Gioitinh = userParam.Gioitinh;
                user.Phone = userParam.Phone;
                user.Diachi = userParam.Diachi;
                user.Roles = userParam.Roles;
            }
            // update password neu no duoc nhap


        }
        public void Delete(int id)
        {
            var user = _context.Users.Find();
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}

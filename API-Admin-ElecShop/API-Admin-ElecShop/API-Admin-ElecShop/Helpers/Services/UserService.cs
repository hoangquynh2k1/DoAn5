using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Helpers;
using API_Admin_ElecShop.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private lkshopContext db = new lkshopContext();
         
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var result = from t in db.TaiKhoans
                         join n in db.NhanViens on t.IdNv equals n.Id
                         select new  User {Role = n.ChucVu,  MaNguoiDung = t.Id, TaiKhoan = t.Username, HoTen = n.HoTen, MatKhau = t.Password, DiaChi = n.DiaChi,DienThoai = n.Sdt,Email = n.Email };
            var user = result.SingleOrDefault(x => x.TaiKhoan == username && x.MatKhau == password);

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
                    new Claim(ClaimTypes.NameIdentifier, user.TaiKhoan.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.DienThoai.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

    }
}
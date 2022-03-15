using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController:BaseApiIController
    {
        public AccountController(DataContext context) : base(context) { }

        [HttpPost("register")]
        public async Task<ActionResult<Tunnel<AppUser>>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512(); //using basically makes sure that once something is used it is disposed of properly. But it has to inhert from the iDispose interface
            Tunnel<AppUser> user = new Tunnel<AppUser>();
            user.Actual= new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                //This will be the default avatar/profile id that will borrow its number from the Tunnelid. 
                avatar=new List<string> { username+ user.TunnelId.Substring(user.TunnelId.Length-5) }
            };

            // To track and store users in the database. If firebase is to be used one must make the change there, since all controllers globally are expected to use this method
            await Store(user);
            return user;

        }

    }
}

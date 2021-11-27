using API.Data;
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
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512(); //using basically makes sure that once something is used it is disposed of properly. But it has to inhert from the iDispose interface
            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            _context.Add(user); // this just tracks the user, it doesnt actually add them. It just makes it possible to
            await _context.SaveChangesAsync(); // this actually saves the user object, note that its async cause mvc cant handle multiple call to save on the same db instance
            return user;

        }


    }
}

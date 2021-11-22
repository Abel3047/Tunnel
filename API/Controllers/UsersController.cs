using API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase    
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            // We are getting this error "FormatException: String '0' was not recognized as a valid DateTime."cause we set dates of our three users to zero, and thats impossible.
            this._context = context; 
        }

        //This means get from api/users
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            foreach (var data in _context.Users)
            {
                data.DateofBirth = DateTime.Parse(data.DateofBirth.ToString());
                //We have this convuluted code cause the date gets changed to string but dont get changed back to date time. This makes sure that happens
            }
            return _context.Users.ToList();

        }

        //This means get from api/users/id 
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)=> _context.Users.Find(id);

    }

}

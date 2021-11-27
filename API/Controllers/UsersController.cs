using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class UsersController: BaseApiIController    
    {

        public UsersController(DataContext context) : base(context) { }

        //This means get from api/users
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            foreach (var data in _context.Users)
            {
                data.DateofBirth = DateTime.Parse(data.DateofBirth.ToString());
                //We have this convuluted code cause the date gets changed to string but dont get changed back to date time. This makes sure that happens
            }
            return  await _context.Users.ToListAsync();

        }

        //This means get from api/users/id 
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)=> await _context.Users.FindAsync(id);

    }

}

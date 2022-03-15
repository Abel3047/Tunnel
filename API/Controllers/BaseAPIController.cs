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
    public class BaseApiIController: ControllerBase
    {
        //Controller are basically how the API talks to the client. Any http requests that come to the API are handles by a controller
        
        // I  want every controller to use this dataContext but im not sure what that will entail
        protected internal readonly DataContext _context;
        public BaseApiIController(DataContext context)
        {
            this._context = context;
        }

        //This method is expected to be used by all controlllers to save work, so please any global changes for saving changes should be done through here, eg firebase change
        //I make it a Task return type cause I wanted to remove the awaitable error I keep getting. But I am not sure if Task is really the absolute best moving forward
        protected async Task Store(object thing)
        {
            // NOTE: Use Dbset with firebase if you do have it on
            _context.Add(thing); // this just tracks the user, it doesnt actually add them. It just makes it possible to
            await _context.SaveChangesAsync(); // this actually saves the Tunnel user object, note that its async cause mvc cant handle multiple call to save on the same db instance
        }



    }
}

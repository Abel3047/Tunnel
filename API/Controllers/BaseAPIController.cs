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
        
        // I  want every controller to use this dataContext but im not sure what that will entail
        protected internal readonly DataContext _context;
        public BaseApiIController(DataContext context)
        {
            this._context = context;
        }
        


    }
}

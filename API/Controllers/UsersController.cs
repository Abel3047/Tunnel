﻿using API.Data;
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
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }
       


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        /*
         This is an application that acts like a time capsule. 
        Essentially, a user would put in a memory/ instance/ status and link or 'tunnel' it with other people mentions, other memories and tunnels.
        The more you tunnel the better. Then whenever you want to look at a place in time, or a memory, everything linked to that pulls and is showcased to you.
        Im also thinking of having an on screen bubble that can capture a website page you are on or link a contact. Its like an instant journal but on steroids.

        I haven't figured out where the network effect is going to come from but since this is practice we shouldn't worry just yet

         
         */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

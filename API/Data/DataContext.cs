using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //I am assuming this is how we set certain sets to search from in a database so you don't have to look through all entries for a query result.
        //This means we don't really need to worry about using Tunnelid to search for everything cause as long as we set the Dbset we are trying to chose
        //from here we can reduce the pool where the search will happen.
        public DbSet<Tunnel<AppUser>> Users { get; set; }


        /*
         * We commenting this out cause we were getting ahead of ourselves
         * 
          protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.avatars);
            // NOTE: There is the key missing. The error we are getting is:
            // The entity type 'AppUser' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.
            // For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.

        }
         
         */


    }
}

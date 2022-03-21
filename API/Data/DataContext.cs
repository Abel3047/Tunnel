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


        
          protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Tunnel<AppUser>>(entity=>
            {
                entity.HasOne<AppUser>(Tu=> Tu.Actual);
                entity.HasKey(Tu => Tu.TunnelId);
            });
            builder.Entity<AppUser>(entity=>
            {
                entity.HasNoKey();
                //entity.HasOne<Tunnel<AppUser>>(); //I don't think this line is necessary
                //.HasMany(ur => ur.avatars);
            });
            // NOTE: There is a missing relational definitionn. The error we are getting is:
            // Unable to determine the relationship represented by navigation 'Tunnel<AppUser>.Actual' of type 'AppUser'.
            // Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or
            // by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.

            // TODO: We have to figure out how to set the dataContext. Searched Changed dataContext dbSet and keep getting. Consider starting the Whole application again
            //Although I don't want to do that. That's such a Yewo thing to do, I want to know how and why I am getting the results I am getting. Restarting isn't an option
            //Check here for where we last were in terms of progress
            //https://stackoverflow.com/questions/55629131/how-to-fix-unable-to-determine-the-relationship-represented-by-navigation-prope 


        }


    }
}

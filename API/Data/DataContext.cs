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

            // TODO: We have to figure out how to set the dataContext. Searched Changed dataContext dbSet and keep getting. 
            // Here we are in terms of progress https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#prerequisites
            // Evidently we are still getting that same relational error within Tunnel<AppUser>.Actual


        }


    }
}

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
        public DbSet<AppUser> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Neccesarry for all the things it was supposed to do anyways, we don't want to rewrite and override everything here now do we
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity =>
            {
                //I put this here so that the key from Tunnel gets propagated into Actual and hopefully solves what I am trying to achieve
                //entity.OwnsMany(user => user.avatars); 
                entity.HasKey(user => user.TunnelId);
                //entity.HasMany(user => user.avatars);
            });
            //builder.Entity<Avatar>(entity =>
            //{
            //    entity.HasMany(Av => Av.ConnectiveAdresses);
            //});

        }


    }
}

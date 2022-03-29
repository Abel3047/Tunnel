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
                entity.HasKey(user => user.TunnelId);
                entity.HasMany(user => user.avatars);
                // NOTE: We don't use OwnsMany() here cause it appears it already exists by default. Consider revising but its not that important 
            });
            builder.Entity<Avatar>(entity =>
            {
                entity.HasMany(Av => Av.AvatarConnectiveAddress);
            });
            builder.Entity<ConnectiveAddress>(entity =>
            {
                entity.HasKey(con => con.ConnectiveId);
            });

        }


    }
}

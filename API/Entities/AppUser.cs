using API.Entities;
using System;

namespace API
{
    public class AppUser : Tunnel
    {
        public AppUser():base()
        {

        }
        public AppUser(object thing, string thingsname):base (thing, thingsname)
        {

        }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        public DateTime DateofBirth { get; set; }
        
        private string _UserName;
        public string UserName { get { return _UserName; } set { if (_UserName != null) { _UserName = value; this.name = _UserName; } } }
        public int Id { get; set; } //UserUniqueId used mostly in the database cause they need a primary key
        public int mobileNumber { get; set; }


        public int numberOfTunnels { get; set; } // number of enteries made
        public int numberofScreens { get; set; } // number of other users they follow
        public int numberofViewers { get; set; } // number of users they follow



    }

}


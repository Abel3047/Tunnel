using API.Entities;
using System;

namespace API
{
    //I have made appuser inhert from abstractTunnel, cause when it is initialized it will be with Tunnel<T>
    //This and others like these will have what appUsers are and can do specially 
    public class AppUser:AbstractTunnel
    {

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


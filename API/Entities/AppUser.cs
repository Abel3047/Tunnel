using API.Entities;
using System;
using System.Collections.Generic;

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
        public List<int> Id { get; set; } //UserUniqueId isn't used and was considered to be used in the making of the Tunnel id. Please use this instead.
        //I'm thinking of making this like a profile, or avatar you chose to work with so that you can have different types of connectives all under one profile
        public int mobileNumber { get; set; }


        public int numberOfTunnels { get; set; } // number of enteries made
        public int numberofScreens { get; set; } // number of other users they follow
        public int numberofViewers { get; set; } // number of users they follow



    }

}


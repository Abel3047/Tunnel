using API.Entities;
using System;

namespace API
{
    public class AppUser : Tunnel
    {
        public AppUser() 
        {
            
        }

        public DateTime DateofBirth { get; set; }
        private string _UserName;
        public string UserName { get { return _UserName; } set { if (_UserName != null) { _UserName = value; this.name = _UserName; } } }
        public int Id { get; set; } //UserUniqueId
        public int mobileNumber { get; set; }


        public int numberOfTunnels { get; set; } // number of enteries made
        public int numberofScreens { get; set; } // number of other users they follow
        public int numberofViewers { get; set; } // number of users they follow



    }

}


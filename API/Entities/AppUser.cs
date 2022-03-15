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
        //Below is set up that way so that it can only change the username once off, then you have to use a method to change it again
        public string UserName { get { return _UserName; } set { if (_UserName == null) { _UserName = value; this.name = _UserName; } } }

        //I'm thinking of making this like a profile, or avatar you chose to work with so that you can have different types of connectives all under one user.
        //So the User will have the option of adding new profiles that will suit different themes and such
        public List<string> avatar { get; set; }
        public int mobileNumber { get; set; }


        public int numberOfTunnels { get; set; } // number of enteries made
        public int numberofScreens { get; set; } // number of other users they follow
        public int numberofViewers { get; set; } // number of users they are followed by

        //I haven't really put up any logic to use this, and I don't really expect to use it, but I put it there so that if we do need it, then all we have to do is
        //Change the access modifier or something, so that with certain security or permission/Premium service we can change it
        private void ChangeUsername(string newUsername) => _UserName = newUsername;

    }

}


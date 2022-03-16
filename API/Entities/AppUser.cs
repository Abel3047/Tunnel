using API.Entities;
using System;
using System.Collections.Generic;

namespace API
{
    //I have made appuser inhert from abstractTunnel, cause when it is initialized it will be with Tunnel<T>
    //This and others like these will have what appUsers are and can do specially 
    public class AppUser:AbstractTunnel
    {
        #region Properties

        //public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        // TODO: We need to set the AppUser Id to the tunnelId cause we need a primary key in the database. Cause the Api end point throws this error
        //The entity type 'AppUser' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.
        //For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.


        public DateTime DateofBirth { get; set; }

        private string _UserName;
        //Below is set up that way so that it can only change the username once off, then you have to use a method to change it again
        public string UserName { get { return _UserName; } set { if (_UserName == null) { _UserName = value; this.name = _UserName; } } }

        //I'm thinking of making this like a profile, or avatar you chose to work with so that you can have different types of connectives all under one user.
        //So the User will have the option of adding new profiles that will suit different themes and such
        //public List<Avatar> avatars { get; set; }

        public int mobileNumber { get; set; }

        #endregion

        #region Methods


        //I haven't really put up any logic to use this, and I don't really expect to use it, but I put it there so that if we do need it, then all we have to do is
        //Change the access modifier or something, so that with certain security or permission/Premium service we can change it
        private void ChangeUsername(string newUsername) => _UserName = newUsername;
        // IDEA: Have the username hidden/private since we will be using AvatarTags anyways. And have a dedicated method that returns the Username.
        // The problems with this idea is that isn't not very different to whats already here. I mean, technically the Username property acting like a 
        // public method that returns the name easy. If you really want there to be conditions on the the access of the username, then edit the get block within the Username

        #endregion


    }

}


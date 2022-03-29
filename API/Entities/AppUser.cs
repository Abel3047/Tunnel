using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Models.Enums;

namespace API
{
    //This and others like these will have what appUsers are and can do specially 

    //[Table("Users")] I put this attribute hoping that it would be explicit enough for the computer. I'm leaving it here in case I need it at somepoint or 
    //place anyways
    public class AppUser:Tunnel
    {
        public AppUser():base()
        {

        }

        #region Properties

        //public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        public DateTime DateofBirth { get; set; }

        private string _UserName;
        //Below is set up that way so that it can only change the username once off, then you have to use a method to change it again
        public string UserName { get { return _UserName; } set { if (_UserName == null) { _UserName = value; this.name = _UserName; } } }

        //I'm thinking of making this like a profile, or avatar you chose to work with so that you can have different types of connectives all under one user.
        //So the User will have the option of adding new profiles that will suit different themes and such
        // TODO: We have to figure out how to map Avatars
        //public List<Avatar> avatars { get; set; }

        public int mobileNumber { get; set; }

        #endregion

        #region Methods

        protected override string MakeTunnelId(string UniqueNumber) => ((int)TunnelTypes.AppUser).ToString() + "0" + generator.CreateId().ToString() + "3" + UniqueNumber;

        //I haven't really put up any logic to use this, and I don't really expect to use it, but I put it there so that if we do need it, then all we have to do is
        //Change the access modifier or something, so that with certain security or permission/Premium service we can change it
        private void ChangeUsername(string newUsername) => _UserName = newUsername;
        // IDEA: Have the username hidden/private since we will be using AvatarTags anyways. And have a dedicated method that returns the Username.
        // The problems with this idea is that isn't not very different to whats already here. I mean, technically the Username property acting like a 
        // public method that returns the name easy. If you really want there to be conditions on the the access of the username, then edit the get block within the Username

        #endregion

    }

}


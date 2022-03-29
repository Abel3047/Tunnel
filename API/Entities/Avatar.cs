using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Avatar:AppUser
    {

        
        #region Properties
        public string AvatarId { get; set; }
        public string AvatarTag { get; set; }

        // Here an Avatars Addresses are recorded so that the User will seem to be different each time. But they will be stored in the Connectives property of every Tunnel
        //contained by the User
        // TODO: I don't think EF knows how to deal with Lists so I'll have to look into that. Here we are in terms of progress https://docs.microsoft.com/en-us/ef/core/modeling/
        public List<string> ConnectiveAdresses { get; set; }
        public int numberOfTunnels { get; set; } // number of enteries made
        public int numberofScreens { get; set; } // number of other users they follow
        public int numberofViewers { get; set; } // number of users they are followed by

        // property for the theme color

        // property for the favourite music

        // property for the favourite colour

        //property for the .......( other dating questions, or traits of individuality, as many as you can find)

        #endregion

        #region Methods

        //This is going to be called when ever we make a post or Avatar or anything. 
        private void DiggTunnel<T>(string thingsName)
        {
            //ConnectiveAdresses.Add(MakeNewTunnel<T>(thingsName));
            numberOfTunnels++;
        }


        //Below here will be all the methods that will make The Tunnels
        // NOTE: I intend to override MakeNewTunnel() here
        #endregion



    }
}

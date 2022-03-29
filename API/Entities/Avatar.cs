using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Avatar : AppUser
    {

        #region Properties
        public string AvatarId { get; set; }
        public string AvatarTag { get; set; }

        // Here an Avatars Addresses are recorded so that the User will seem to be different each time. But they will be stored in the Connectives property of every Tunnel 
        // made and contained by the User

        //Instead of using a list of strings like I normally would it seems EF doesn't know how to map lists. So I made a collection of records to compare the values instead
        public ICollection<ConnectiveAddress> AvatarConnectiveAddress { get; set; }
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
        // TODO: Here should be the methods for making post and stuff, this is where we will do all the magic
        private void DiggTunnel<T>(string thingsName)
        {
            //ConnectiveAdresses.Add(MakeNewTunnel<T>(thingsName));
            numberOfTunnels++;
        }


        //Below here will be all the methods that will make The Tunnels
        // NOTE: I intend to override MakeNewTunnel() here

        protected internal override string MakeNewTunnel<TTunnel>(string name)
        {
            //I still want it to do all the things that happen in the base logic
            base.MakeNewTunnel<TTunnel>(name);

            //Insert made logic here, I didn't actually do any work here
            //.......... On second thought I am considering wrapping this method in public methods and returning this method to just protected

            DiggTunnel<TTunnel>(name);
            return name;
        }
        #endregion

    }
}

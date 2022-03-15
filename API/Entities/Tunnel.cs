using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Models.Enums;

namespace API.Entities
{
    public class Tunnel<T>:AbstractTunnel
    {

        //All Tunnel objects will be initialized using this class. So It will be like Tunnel<Object>();
        //I don't actually intend to store raw classes like AppUser or post or something. All things will be Tunnels with the type attached to it.
        //Most of the business logic will be done in here and the controllers. The classes will exist mostly as data and property holders only
        public T Actual { get; set; }
        public Tunnel()
        {
            //This defines what a tunnel can and will do

            Random random = new Random();
            string r = random.Next(10000, 99999).ToString();
            switch (Actual)
            {
                //We use ((int)TunnelTypes.Tunnel).ToString() to make sure that we get the number and not the name
                //Theres no use in making a unique id based on the user name, we just use a random Id generator
                case AppUser:
                    TunnelId = ((int)TunnelTypes.AppUser).ToString() + "0" + generator.CreateId().ToString() + "3" + r;
                    break;
                    //I want to put Post as a type here.
                default:
                    TunnelId = ((int)TunnelTypes.Tunnel).ToString() + "0" + r;
                    break;
            }
            //Sets the name to a random name This is to be changed by the user doe at some point. Note: Don't use this as an identifier
            name = "Tunnel"+r;
        }

        public readonly string TunnelId; 
       
        /*
        All methods below this one will be used for the business logic that won't be expected in the Controllers.
        This is where those Tunnel exclusive features will come up
         */

        public override string ToString()
        {
            return $"This a Tunnel named {this.name}, We expect to put more here like features and stuff, but we haven't put in any new stuff yet";
        }
    }
}

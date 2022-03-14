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
        //I don't actually intend to store raw classes like AppUser or psot or something. All things will be Tunnels with the type attached to it.
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
                case AppUser:
                    TunnelId = int.Parse(((int)TunnelTypes.AppUser).ToString() + DateTime.Now.ToString() + "0" + r);
                    break;
                default:
                    TunnelId = int.Parse(((int)TunnelTypes.Tunnel).ToString() + DateTime.Now.ToString() + "0" + r);
                    break;
            }
            //Sets the name to a random name
            name = "Tunnel"+r;
        }

        public readonly int TunnelId; 
        // TODO: This to be done
        // It will be TunnelTypeNumber+DateTime+'0'+userUniqueId'3'+random5digitnumber, needs to be public so it can be added to Connectives of others

        /*
         This exists cause we need to be able to make new tunnels

        All methods below this one will be used for the business logic that won't be expected in the Controllers
         */

        public override string ToString()
        {
            return $"This a Tunnel named {this.name}, We expect to put more her like features and stuff, but we haven't put in any new stuff yet";
        }
    }
}

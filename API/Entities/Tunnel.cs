using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Tunnel:AbstractTunnel
    {
        public Tunnel():base()
        {

        }
        public Tunnel(object thing, string thingsname) : base( thing,thingsname) //so that when this constructor is called it the one defined in the superclass
        {

        }
        /*
         This exists cause we need to be able to make new tunnels
         */
    }
}

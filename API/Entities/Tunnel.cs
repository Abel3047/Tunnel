using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Tunnel : TunnelObject
    {
        public Tunnel()
        {

        }
        public Tunnel(object thing, string thingsname) : base(thing, thingsname)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    //I use record here cause I want to be able to compare values and not pointers.
    public record ConnectiveAddress
    {
        //It might be helpful to access the AvatarAddresses with a key. But otherwise this exists cause EF wants a key. We could remove it but this is good so far
        public string ConnectiveId { get; set; }
        public string Address { get; set; }

        // if they want the Address they can do so with this method as well. 
        public override string ToString()=> Address;

    }
}

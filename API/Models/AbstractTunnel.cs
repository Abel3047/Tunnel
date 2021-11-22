using API.Entities;
using System;
using System.Collections.Generic;

namespace API
{
	public abstract class AbstractTunnel
	{
        public AbstractTunnel()
        {
			Random random = new Random();
			this.TunnelId = DateTime.Now.ToString() + "0" + random.Next(10000, 99999).ToString();
		}
		public AbstractTunnel(object thing, string thingsname)
		{
			SetActual(thing, thingsname);
			Random random = new Random();
			this.TunnelId = DateTime.Now.ToString() + "0" + random.Next(10000, 99999).ToString()+this.name ;
		}

        public string name { get; set; }
		public readonly string TunnelId; // It will be DateTime'0'userUniqueId'3'random5digitnumber, needs to be public so it can be added to Connectives of others
		private Dictionary<string, object> Connectives { get; set; } // will be a list of all connected tunnel ids

		// this is where the actual thing used to represent the tunnel will be stored. its private for security, 
		//its inherted by all base classes but needs the SetActual() for it to be useful
		private object Actual { get; set; } 
		// Its protected cause only classes that inhert from this class should have access to it
		protected void SetActual(object thing, string thingsname)
        {
			this.Actual = thing;
			this.name = thingsname;
		}

        public void MakeNewTunnel(object thing, string thingsname)
		{
			Tunnel tunnelObject = new Tunnel(thing, thingsname);
			this.Connectives.Add(tunnelObject.TunnelId, tunnelObject);
			// Note that tunnel can be an or list of objects
		}

		public object GetConnection(string tunnelid)=> Connectives[tunnelid]; // returns the tunnel its looking for
		public object GetAllConnections() => Connectives;// returns all the connections made

	}
}


using API.Entities;
using System;
using System.Collections.Generic;
using static API.Models.Enums;

namespace API
{
	public abstract class AbstractTunnel
	{
		//This defines what a tunnel should be and act like
		//This is cause subclassed do define something in their constructors
		public AbstractTunnel()
		{
			
		}
		//Everyone should be aleast able to see the name and id
        public string name { get; set; }
        private Dictionary<int, object> Connectives { get; set; } // will be a list of all connected tunnel ids

        public void MakeNewTunnel<T>(string thingsname)
		{
			Tunnel<T> tunnelObject = new Tunnel<T>();
			tunnelObject.GiveTunnelName(thingsname);
			this.Connectives.Add(tunnelObject.TunnelId, tunnelObject);
			// Note that tunnel can be an or list of objects
		}
		public void GiveTunnelName(string thingsname) => name = thingsname;
		public object GetConnection(int tunnelid)=> Connectives[tunnelid]; // returns the tunnel its looking for by tunnel Id
		public object GetAllConnections() => Connectives;// returns all the connections made

	}
}


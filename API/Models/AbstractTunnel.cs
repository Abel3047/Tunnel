using API.Entities;
using IdGen;
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
		//Everyone should be aleast able to see the name and id. Note that the name is just for the user. It should not be used as an Id
        public string name { get; set; }
		//I need this to be static, cause I only want one generator for the uniqueUser Id
		protected static IdGenerator generator = new IdGenerator(0);
		private Dictionary<string, object> Connectives { get; set; } // will be a list of all connected tunnel ids

        public void MakeNewTunnel<T>(string thingsname)
		{
			Tunnel<T> tunnelObject = new Tunnel<T>();
			tunnelObject.GiveTunnelName(thingsname);
			this.Connectives.Add(tunnelObject.TunnelId, tunnelObject);
			// NOTE: that tunnel can be an object or list of objects
		}
		public void GiveTunnelName(string thingsname) => name = thingsname;
		public object GetConnection(string tunnelid)=> Connectives[tunnelid]; // returns the tunnel its looking for by tunnel Id
		public object GetAllConnections() => Connectives;// returns all the connections made

	}
}


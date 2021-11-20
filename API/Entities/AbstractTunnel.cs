using API.Entities;
using System;
using System.Collections.Generic;

namespace API
{
	public abstract class TunnelObject
	{
        public TunnelObject()
        {
			Random random = new Random();
			this.TunnelId = DateTime.Now.ToString() + "0" + random.Next(10000, 99999).ToString();
		}
		public TunnelObject(object thing, string thingsname)
		{
			starteds = true;
			this.Actual = thing; starteds = false;
			this.name = thingsname;
			Random random = new Random();
			this.TunnelId = DateTime.Now.ToString() + "0" + random.Next(10000, 99999).ToString()+this.name ;
		}
		private bool starteds = false;

        public string name { get; set; }
		public string TunnelId { get; set; } // It will be DateTime'0'userUniqueId'3'random5digitnumber, needs to be public so it can be added to Connectives of others

		private List<string> Connectives { get; set; } // will be a list of all connected tunnel ids


		private object _actual { get; set; }
		public object Actual { get { return _actual; } set { if(starteds==true) _actual = value; } } // this is where the actual thing used to represent the tunnel will be stored.

		public void MakeNewTunnel(object thing, string thingsname)
		{
			Tunnel tunnelObject = new Tunnel(thing, thingsname);
			this.Connectives.Add(tunnelObject.TunnelId);
			// Note that tunnel can be an or list of objects
		}

		public string GetConnection(string id)
		{
			return null; // returns the tunnel its looking for
		}
	}
}


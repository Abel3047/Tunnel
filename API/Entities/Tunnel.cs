using IdGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Models.Enums;

namespace API.Entities
{
    public class Tunnel
    {
        // TODO: Remove BernardPixel from the Git History probably by rebaseing the whole master branch
        /*This defines what a tunnel should be and act like. Tunnels are any linkable set of things on the application.
     * more accurately, I wish to be able to link dates, posts, blogs and users and reactions to each other. So you can
     * go in a chain from one reaction to another. Like a mini web. Of course some tunnels will be accessable only with certain permissions.
     * But one should be able to start and finish and make and prune their own world as they see fit in whatever Avatars they are using.
     * I intend the Tunnels to literally be anything, from a string to a date. But it seems wiser to use Tunnel for more specific things, like posts and the 
       like, instead of just value types
       Most of the business logic will be done in here except the controllers. 
     */


        public Tunnel()
        {
            //This is logic for setting the id and default name of a Tunnel
            //I don't expect this to change, but if changes are to be made its to the methods below( they are virtual)
            string r = SetTunnelName();
            TunnelId = MakeTunnelId(r);
        }

        #region Properties

        //Everyone should be aleast able to see the name and id. Note that the name is just for the user. It should not be used as an Id
        public readonly string TunnelId;
        public string name { get; set; }
        public TunnelTypes tunnelType { get; set; }

        //I need this to be static, cause I only want one generator for the uniqueUser Id
        protected static IdGenerator generator = new IdGenerator(0);
        // NOTE: This is private cause a method exists that accesses this. There is no reason why you should access it directly SO DON'T CHANGE IT
        private Dictionary<string, object> Connectives { get; set; } // will be a list of all connected tunnel ids
        #endregion

        #region Methods

        //I expect Tunnels to be made differently for different tunnels
        //I use protected internal cause I want to be able to call it in other classes, but I can't have all assemblies accessing it
        protected internal virtual string MakeNewTunnel<TTunnel>(string thingsname) where TTunnel:Tunnel //I am hoping I can have primitive types wrapped under Tunnel as well
        {
            // NOTE: This only works with parameterless constructors, we will have to make changes if you consider changing
            Tunnel tunnelObject = (Tunnel)Activator.CreateInstance(typeof(TTunnel));
            tunnelObject.GiveTunnelName(thingsname);
            //This adds the tunnel just made to the connectives of the tunnel that made it, so its important that it doesn't get removed, cause 
            //It doesn't happen anywhere else
            // NOTE: that tunnel can be an object or list of objects
            this.Connectives.Add(tunnelObject.TunnelId, tunnelObject);

            //We need the tunnel id to be stored by the Avatar that makes it
            return tunnelObject.TunnelId;
        }

        //I intend for different tunnels to have different conditions to change names and such
        protected virtual void GiveTunnelName(string thingsname) => name = thingsname;
        public object GetConnection(string tunnelid) => Connectives[tunnelid]; // returns the tunnel its looking for by tunnel Id
        public object GetAllConnections() => Connectives;// returns all the connections made

        //Returns the unique number made that's attached to the Name. It should be used everytime you want to set the name of a tunnel
        protected virtual string SetTunnelName()
        {
            Random random = new Random();
            string r = random.Next(10000, 99999).ToString();
            //Sets the name to a random name This is to be changed by the user doe at some point. Note: Don't use this as an identifier
            name = "Tunnel" + r+ this.GetType().ToString();
            return r;
        }

        // REFACTOR: Consider using GetType().ToString() instead of the Enum 
        //We use ((int)TunnelTypes.Tunnel).ToString() to make sure that we get the number and not the name
        //Theres no use in making a unique id based on the user name, we just use a random Id generator
        //
        protected virtual string MakeTunnelId(string UniqueNumber) => ((int)TunnelTypes.Tunnel).ToString() + "0" + UniqueNumber;






        /*
        All methods below this one will be used for the business logic that won't be expected in the Controllers.
        This is where those Tunnel exclusive features will come up
         */
        public override string ToString()
        {
            return $"This a Tunnel named {this.name}, We expect to put more here like features and stuff, but we haven't put in any new stuff yet";
        }
        #endregion


        // IDEA: Have string and other primitive value types wrapped in a tunnel subclass , that way we can have access to them like a tunnel
    }
}

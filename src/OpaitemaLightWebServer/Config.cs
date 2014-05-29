using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpaitemaLightWebServer
{
    /// <summary>
    /// General Configuration (Singleton)
    /// </summary>
    public class Config
    {         
        private static Config instance;

        private Config() { }

        public static Config Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }

        /// <summary>
        /// Directory where the resources of each request
        /// </summary>
        public string RootDirectory { get; set; }

        /// <summary>
        /// Http port
        /// </summary>
        public int Port { get; set; }

        public string Uri
        {
            get {
            return String.Format("http://localhost:{0}", Port.ToString());
        }
        }

        /// <summary>
        /// View each item of the request in the query
        /// </summary>
        public bool DebugRequest { get; set; }
        
        
    }
}

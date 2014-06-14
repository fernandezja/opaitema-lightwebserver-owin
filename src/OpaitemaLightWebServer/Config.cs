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
        /// Default Document
        /// </summary>
        public string DefaultDocument { get; set; }

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


        public string GetMimeFromExtension(string extension) {

            //TODO: Basic ContentType ... should get a ContentType from scheme Helper. 
            var contentType = string.Empty;

            switch (extension)
            {
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;

                case ".css":
                    contentType = "text/css";
                    break;

                case ".js":
                    contentType = "application/javascript";
                    break;

                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;

                case ".png":
                    contentType = "image/png";
                    break;

                case ".mp4":
                    contentType = "video/mp4";
                    break;

                case ".oga":
                    contentType = "audio/ogg";
                    break;

                case ".ogv":
                    contentType = "video/ogg";
                    break;

                case ".webm":
                    contentType = "video/webm";
                    break;

                case ".json":
                    contentType = "application/json";
                    break;

                default:
                    contentType = "application/octet-stream";
                    break;

            }

            return contentType;

        }
        
    }
}

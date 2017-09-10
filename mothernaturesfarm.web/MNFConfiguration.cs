using System;
using System.Configuration;

namespace mothernaturesfarm.web
{
    public class MNFConfiguration
    {
        private const string CFG_DEF_CONNECTION_STRING_KEY = "mnf.cnstr";
        /// <summary>
        /// Gets the DB connection string key.  This is the KEY used to retrieve the connection string, not
        /// the connectionstring itself.  Only the Key is needed when using Enterprise Library for data access.
        /// </summary>
        public static string DBConnectionStringKey
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_DEF_CONNECTION_STRING_KEY]))
                    return (ConfigurationManager.AppSettings[CFG_DEF_CONNECTION_STRING_KEY]);
                throw new Exception("Connection String Not Defined");
            }
        }
    }
}
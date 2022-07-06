using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure
{
    public static class Constants
    {
        public static class ConnectionStrings
        {
            public const string DefaultConnection = "Server=.\\SQLEXPRESS;Initial Catalog=DataEntryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public static class JwtToken
        {
            public static string ValidAudience = "dataentryapi";
            public static string ValidIssuer = "https://localhost:44309";
            public static string Secret = "ThisIsToFulfillAJobRequirement";
        }

        public static class MainDetails
        {
            public static string Api = "https://localhost:7045/api/";
        }
    }
}

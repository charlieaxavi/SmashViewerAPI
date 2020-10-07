using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashViewerClient.Models.Configuration
{
    public class ConfigurationAPI
    {
        //Address del Api
        //Development
        // public string apiURL = "http://192.168.250.89:3010/api/";
        public string apiURL = "https://localhost:44316/api/";
        //OwnComputer
        public TimeSpan waitingAnswers = DateTime.Parse("2020-01-01 00:30:00").TimeOfDay;
        public string getUser()
        {
            //string userID = HttpContext.Current.User.Identity.Name;
            //return userID;
            return null;
        }
    }
}

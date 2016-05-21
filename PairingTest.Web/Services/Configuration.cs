using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Services
{
    public class Configuration : IConfiguration
    {
        public string GetAppSetting(string key)
        {
           return ConfigurationManager.AppSettings[key];
        }
    }
}
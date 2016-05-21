using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IConfiguration
    {
        string GetAppSetting(string key);
    }
}

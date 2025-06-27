using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public  class DBPropertyUtil
    {
        public static string GetPropertyString()
        {
            //return ConfigurationManager.ConnectionStrings["MyConnection"]?.ConnectionString;
            return "server=LAPTOP-L4FV7ODF\\SQLEXPRESS01;database=InsuranceDb;Trusted_Connection=true";
        }
    }
}

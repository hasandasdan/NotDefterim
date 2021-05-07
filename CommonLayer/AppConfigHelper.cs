using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class AppConfigHelper
    {
        //ConfigurationManager için referans olarak System.Configuration ekleyip app.configteki değeri namele almak için  
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;// gönderdiğimiz name in oku onun connectionstrigini geri ver

        }
    }
}

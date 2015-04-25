using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SharedKernal.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

    }
}

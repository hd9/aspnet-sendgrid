using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSendGrid.Core.Config
{
    public class AppConfig
    {
        public SmtpOptions SmtpOptions { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
    }
}

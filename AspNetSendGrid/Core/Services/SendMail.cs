using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSendGrid.Core.Services
{
    public class SendMail
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString() =>
            $"{Name} <{Email}>";
    }
}

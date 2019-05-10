using System;
using System.Collections.Generic;
using System.Text;

namespace YourDollar.API.Infrastructure.Entities
{
    public class OktaConfig
    {
        public string TokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

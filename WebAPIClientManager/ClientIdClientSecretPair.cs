using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClientManager
{
    public class ClientIdClientSecretPair
    {
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

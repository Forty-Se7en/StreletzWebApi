using System.ComponentModel;

namespace StreletzProxyServer.Requests
{
    public class ConnectRequest
    {
        [DefaultValue("http://DESKTOP-KILC044:8030")]
        public string Address { get; set; }
    }
}

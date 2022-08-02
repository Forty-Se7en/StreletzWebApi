using System.ComponentModel;

namespace StreletzProxyServer.Requests
{
    public class ConnectRequest
    {
        [DefaultValue("http://DESKTOP-FUH7PGF:8030")]
        public string Address { get; set; }
    }
}

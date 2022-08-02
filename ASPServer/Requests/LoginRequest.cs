using System.ComponentModel;

namespace StreletzProxyServer.Requests
{
    public class LoginRequest
    {
        [DefaultValue("web1")]
        public string UserName { get; set; }

        [DefaultValue("a1a1a1a1")]
        public string Password { get; set; }
    }
}

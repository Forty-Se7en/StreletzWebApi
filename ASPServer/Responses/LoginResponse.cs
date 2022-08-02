namespace StreletzProxyServer.Responses
{
    public class LoginResponse
    {
        public bool Authenticated { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public string ErrorMessage { get; set; }
    }
}

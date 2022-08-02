namespace StreletzProxyServer.Requests
{
    public class SendMessageRequest
    {
        public string[] Recipients { get; set; }

        public string[] Params { get; set; }
    }
}

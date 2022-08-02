using Swashbuckle.AspNetCore.Annotations;

namespace StreletzProxyServer.Requests
{
    public class ExecuteCommandRequest
    {        
        public string CommandGuid { get; set; }

        public string[] Recipients { get; set; }

        public string[] Params { get; set; }
    }
}

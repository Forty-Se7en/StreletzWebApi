using StreletzAPI.Json;

namespace StreletzProxyServer.Responses
{
    public class LogicalObjectResponse
    {
        /// <summary>
        /// Описание объекта            
        /// </summary>
        public List<Guid> ChildObjectsList { get; set; }

        public static LogicalObjectResponse FromLogicalObjectInfo(LogicalObjectInfo info)
        {
            return new LogicalObjectResponse()
            {
                ChildObjectsList = info.ChildObjectsList
            };

        }
    }
}

using Newtonsoft.Json;


namespace StreletzAPI.Json
{
    /// <summary>
    /// Вспомогательный класс для JSON сериализации AccessInfo
    /// </summary>
    public class AccessInfo
    {
        /// <summary>
        /// userName.
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// userRole.
        /// </summary>
        [JsonProperty("userRole")]
        public string UserRole { get; set; }

        /// <summary>
        /// notAuthenticated.
        /// </summary>
        [JsonProperty("notAuthenticated")]
        public string NotAuthenticated { get; set; }
    }
}

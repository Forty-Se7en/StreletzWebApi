using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Базовая инфа, содержащая в себе информацию об объекте и его состоянии.
    /// </summary>
    [Serializable]
    public class BaseStateInfo
    {
        public BaseStateInfo() { }

        /// <summary>
        /// Info объекта
        /// </summary>
        [JsonProperty("info")]
        public Info Info { get; set; }

        /// <summary>
        /// Статус объекта
        /// </summary>
        [JsonProperty("state")]
        public State State { get; set; }
    }
}

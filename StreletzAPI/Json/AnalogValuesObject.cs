using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Base class containing info about 
    /// analog values source and its state
    /// </summary>
    [Serializable]
    public class AnalogValuesObject
    {
        public AnalogValuesObject()
        { }

        /// <summary>
        /// Info объекта
        /// </summary>
        [JsonProperty("analogValuesInfo")]
        public AnalogValuesInfo AvInfo { get; set; }

        /// <summary>
        /// Статус объекта
        /// </summary>
        [JsonProperty("analogValuesState")]
        public AnalogValuesState AvState { get; set; }

    }
}

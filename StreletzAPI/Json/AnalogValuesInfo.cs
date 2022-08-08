using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    // <summary>
    /// Info, describing analog values source
    /// </summary>
    [Serializable]
    public class AnalogValuesInfo : Info
    {
        public AnalogValuesInfo()
        { }

        /// <summary>
        /// Сегмент.
        /// </summary>
        [JsonProperty("segment")]
        public string Segment { get; set; }

        /// <summary>
        /// Устройство.
        /// </summary>
        [JsonProperty("device")]
        public string Device { get; set; }

        /// <summary>
        /// Датчик.
        /// </summary>
        [JsonProperty("sensor")]
        public string Sensor { get; set; }

        ///// <summary>
        ///// Ключ к Иконке.
        ///// </summary>
        //[JsonProperty("icon")]
        //public string Icon { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        [JsonProperty("sensorType")]
        public string SensorType { get; set; }

        /// <summary>
        /// Раздел.
        /// </summary>
        [JsonProperty("partition")]
        public string Partition { get; set; }

        /// <summary>
        /// Род.РР.
        /// </summary>
        [JsonProperty("radioParent")]
        public string RadioParent { get; set; } // RadioParent - родительский РР в радиоканале

        /// <summary>
        /// Ан. тип 1
        /// </summary>
        [JsonProperty("typeAnalog1")]
        public string TypeAnalog1 { get; set; }

        /// <summary>
        /// Ан. тип 2
        /// </summary>
        [JsonProperty("typeAnalog2")]
        public string TypeAnalog2 { get; set; }

        /// <summary>
        /// Ан. тип 3
        /// </summary>
        [JsonProperty("typeAnalog3")]
        public string TypeAnalog3 { get; set; }

        /// <summary>
        /// Ан. тип 4
        /// </summary>
        [JsonProperty("typeAnalog4")]
        public string TypeAnalog4 { get; set; }

        ///// <summary>
        ///// Описание объекта
        ///// </summary>
        //[JsonProperty("childObjectsList")]
        //public List<Guid> ChildObjectsList { get; set; }
    }
}

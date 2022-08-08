using Newtonsoft.Json;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Info, describing analog values source state
    /// </summary>
    [Serializable]
    public class AnalogValuesState : ObjectToken
    {
        public AnalogValuesState()
        { }

        /// <summary>
        /// Актуальность
        /// </summary>
        [JsonProperty("actuality")]
        public string Actuality { get; set; }

        /// <summary>
        /// Background color Актуальность
        /// </summary>
        [JsonProperty("actualityColor")]
        public string ActualityColor { get; set; }

        /// <summary>
        /// ОП.
        /// </summary>
        [JsonProperty("op")]
        public string OP { get; set; }

        /// <summary>
        /// Background color ОП.
        /// </summary>
        [JsonProperty("opColor")]
        public string OPcolor { get; set; }

        /// <summary>
        /// РП.
        /// </summary>
        [JsonProperty("rp")]
        public string RP { get; set; }

        /// <summary>
        /// Background color РП.
        /// </summary>
        [JsonProperty("rpColor")]
        public string RPcolor { get; set; }

        /// <summary>
        /// Неисправность.
        /// </summary>
        [JsonProperty("fault")]
        public string Fault { get; set; }

        /// <summary>
        /// Background color Неисправность.
        /// </summary>
        [JsonProperty("faultColor")]
        public string FaultColor { get; set; }

        /// <summary>
        /// Корпус.
        /// </summary>
        [JsonProperty("dv")]
        public string DV { get; set; }

        /// <summary>
        /// Background color Вскрыт/Закрыт
        /// </summary>
        [JsonProperty("dvColor")]
        public string DVcolor { get; set; }

        /// <summary>
        /// Температура.
        /// </summary>
        [JsonProperty("temp")]
        public string Temp { get; set; }

        /// <summary>
        /// Ан. знач 1.
        /// </summary>
        [JsonProperty("analog1")]
        public string Analog1 { get; set; }

        /// <summary>
        /// ForeColor analog1
        /// </summary>
        [JsonProperty("analog1ForeColor")]
        public string Analog1ForeColor { get; set; }

        /// <summary>
        /// Ан. знач 2.
        /// </summary>
        [JsonProperty("analog2")]
        public string Analog2 { get; set; }

        /// <summary>
        /// ForeColor analog2
        /// </summary>
        [JsonProperty("analog2ForeColor")]
        public string Analog2ForeColor { get; set; }

        /// <summary>
        /// Ан. знач 3.
        /// </summary>
        [JsonProperty("analog3")]
        public string Analog3 { get; set; }

        /// <summary>
        /// ForeColor analog3
        /// </summary>
        [JsonProperty("analog3ForeColor")]
        public string Analog3ForeColor { get; set; }

        /// <summary>
        /// Ан. знач 4.
        /// </summary>
        [JsonProperty("analog4")]
        public string Analog4 { get; set; }

        /// <summary>
        /// ForeColor analog4
        /// </summary>
        [JsonProperty("analog4ForeColor")]
        public string Analog4ForeColor { get; set; }

        /// <summary>
        /// Актуальность.
        /// </summary>
        [JsonProperty("dateTime")]
        public DateTime? TimePoint { get; set; }
    }
}
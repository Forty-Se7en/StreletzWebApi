using System;
using Newtonsoft.Json;

namespace StreletzAPI.Json
{

    /// <summary>
    /// Вспомогательный класс для JSON сериализации Geodata
    /// </summary>
    public class GeoData : ObjectToken
    {
        /// <summary>
        /// Широта.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота.
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Точность.
        /// </summary>
        [JsonProperty("precision")]
        public double Precision { get; set; }

        /// <summary>
        /// Временная метка может быть не назначена.
        /// </summary>
        [JsonProperty("timePoint")]
        public DateTime TimePoint { get; set; }

        /// <summary>
        /// Состояние GNSS.
        /// </summary>
        [JsonProperty("gnssOn")]
        public bool GnssOn { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }

        /// <summary>
        /// Средняя скоросто на отрезке в км/ч.
        /// Если это начало трека, то null.
        /// </summary>
        [JsonProperty("avgSpeed")]
        public double? AvgSpeed { get; set; }

        /// <summary>
        /// Расстояние от предыдущей точки до этой.
        /// Если это начало трека, то null.
        /// </summary>
        [JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// Продолжительность отрезка. Вычисляется по разнице временных меток.
        /// Если это начало трека, то null.
        /// </summary>
        [JsonProperty("duration")]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// определяет тип источника geodata 
        /// (см. enum Core.Managment.GeodataSources)
        /// </summary>
        [JsonProperty("geodataSource")]
        public int GeodataSource { get; set; }

        /// <summary>
        /// определяет валидность координат 
        /// </summary>
        [JsonProperty("coordinatesFixed")]
        public bool CoordinatesFixed { get; set; }

        /// <summary>
        /// ID графического плана 
        /// </summary>
        [JsonProperty("localSchemaId")]
        public int? LocalSchemaId { get; set; }
    }
}

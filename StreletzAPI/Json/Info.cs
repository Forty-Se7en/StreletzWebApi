using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Info, описывающее устройство или логический объект
    /// </summary>
    [Serializable]
    public class Info : ObjectToken
    {
        //        /// <summary>
        //        /// Guid сегмента
        //        /// </summary>
        //        [JsonProperty]
        //        public Guid SegmentGuid { get; set; }

        /// <summary>
        /// Номер устройства/логического объекта согласно вложенности его в общем дереве
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Наименование устройства/прибора
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Пользовательское описание, заданное для устройства
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Тип устройства согласно таблицы экпорта
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// Подтип устройства согласно таблицы экпорта
        /// </summary>
        [JsonProperty("subtype")]
        public int Subtype { get; set; }

        /// <summary>
        /// Ключ к Иконке 
        /// (Имя иконки без расширения).
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}

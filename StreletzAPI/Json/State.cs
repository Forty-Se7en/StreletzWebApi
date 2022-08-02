using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Состояние логического объекта или устройства
    /// </summary>
    [Serializable]
    public class State : ObjectToken
    {
        /// <summary>
        /// Флаги состояний
        /// </summary>
        [JsonProperty("flags")]
        public StateFlags Flags { get; set; }

        ///// <summary>
        ///// Флаги состояний
        ///// </summary>
        //[JsonProperty("condition")]
        //[JsonConverter(typeof(StringEnumConverter))]
        //public StateCondition Condition { get; set; }

        /// <summary>
        /// Описание состояния объекта
        /// </summary>
        [JsonProperty("objectState")]
        public string ObjectState { get; set; }

        /// <summary>
        /// Код состояния объекта:
        /// <para>0 - Выключен.</para>
        /// <para>1 - Взят на охрану.</para>
        /// <para>2 - Снят с охраны. Норма.</para>
        /// <para>3 - Снят с охраны. Нарушен.</para>
        /// <para>4 - Неисправность, Взлом, Обход.</para>
        /// <para>5 - Задержка на взятие/снятие.</para>
        /// <para>6 - Блокировка.</para>
        /// <para>7 - Активация.</para>
        /// <para>8 - Пожарное внимание.</para>
        /// <para>9 - Тревоги: Охранная, Пожар, Паника, Принуждение, Технологическая.</para>
        /// </summary>
        [JsonProperty("objectStateCode")]
        public int ObjectStateCode { get; set; }

        /// <summary>
        /// Цвет состояния объекта
        /// </summary>
        [JsonProperty("stateCssColor")]
        public string ObjectStateCssColor { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    [Serializable]
    public class StateFlags
    {
        /// <summary>
        /// Тревога Охранная.
        /// </summary>
        [JsonProperty("warningGuard")]
        public bool WarningGuard { get; set; }

        /// <summary>
        /// Тревога Паника.
        /// </summary>
        [JsonProperty("warningPanic")]
        public bool WarningPanic { get; set; }

        /// <summary>
        /// Тревога Принуждение.
        /// </summary>
        [JsonProperty("warningCompulsion")]
        public bool WarningCompulsion { get; set; }

        /// <summary>
        /// Тревога Пожарная.
        /// </summary>
        [JsonProperty("warningFire")]
        public bool WarningFire { get; set; }

        /// <summary>
        /// Тревога Пожарное внимание.
        /// </summary>
        [JsonProperty("warningFireAttension")]
        public bool WarningFireAttension { get; set; }

        /// <summary>
        /// Тревога Технологическая.
        /// </summary>
        [JsonProperty("warningTechnological")]
        public bool WarningTechnological { get; set; }

        /// <summary>
        /// Нарушение.
        /// </summary>
        [JsonProperty("break")]
        public bool Break { get; set; }

        /// <summary>
        /// Взятие.
        /// </summary>
        [JsonProperty("delaysGuardOn")]
        public bool DelaysGuardOn { get; set; }

        /// <summary>
        /// Задержка.
        /// </summary>
        [JsonProperty("delaysDelay")]
        public bool DelaysDelay { get; set; }

        /// <summary>
        /// Перевзятие.
        /// </summary>
        [JsonProperty("delaysReGuard")]
        public bool DelaysReGuard { get; set; }

        /// <summary>
        /// Неисправность.
        /// </summary>
        [JsonProperty("disrepairsDisrepair")]
        public bool DisrepairsDisrepair { get; set; }

        /// <summary>
        /// Взлом.
        /// </summary>
        [JsonProperty("disrepairsBreaking")]
        public bool DisrepairsBreaking { get; set; }

        /// <summary>
        /// Обход.
        /// </summary>
        [JsonProperty("disrepairsRound")]
        public bool DisrepairsRound { get; set; }

        /// <summary>
        /// Активация.
        /// </summary>
        [JsonProperty("activation")]
        public bool Activation { get; set; }

        /// <summary>
        /// Блокировка.
        /// </summary>
        [JsonProperty("block")]
        public bool Block { get; set; }

        /// <summary>
        /// Пожар в зоне пожарной автоматики.
        /// </summary>
        [JsonProperty("extiguisherZoneFire")]
        public bool ExtiguisherZoneFire { get; set; }

        /// <summary>
        /// Успешный запуск УПА.
        /// </summary>
        [JsonProperty("successfulStart")]
        public bool SuccessfulStart { get; set; }
    }
}

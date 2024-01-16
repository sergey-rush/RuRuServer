using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RuRuServer.Models
{
    /// <summary>
    /// Данные карты
    /// </summary>
    public class CardData
    {
        /// <summary>
        /// Имя и Фамилия
        /// </summary>
        [JsonProperty("cardholder")]
        public string Cardholder { get; set; }

        /// <summary>
        /// CVV2 код
        /// </summary>
        [JsonProperty("cvc")]
        [Required]
        public string Cvc { get; set; }

        /// <summary>
        /// Месяц окончания срока действия карты в формате MM
        /// </summary>
        [JsonProperty("exp_month")]
        [Required]
        public string ExpMonth { get; set; }

        /// <summary>
        /// Год окончания срока действия карты в формате YY
        /// </summary>
        [JsonProperty("exp_year")]
        [Required]
        public string ExpYear { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        [JsonProperty("pan")]
        [Required]
        public string Pan { get; set; }
    }
}

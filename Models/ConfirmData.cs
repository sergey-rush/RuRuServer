using Newtonsoft.Json;

namespace RuRuServer.Models
{
    /// <summary>
    /// Данные для прохождения 3-D Secure
    /// </summary>
    public class ConfirmData
    {
        /// <summary>
        /// ACS Url
        /// </summary>
        [JsonProperty("acs_url")]
        public string AcsUrl { get; set; }

        /// <summary>
        /// Merchant Data
        /// </summary>
        [JsonProperty("md")]
        public string Md { get; set; }

        /// <summary>
        /// Payer Authentication Request
        /// </summary>
        [JsonProperty("pareq")]
        public string Pareq { get; set; }

        /// <summary>
        /// Адрес для возврата md/pares после аутентификации пользователя
        /// </summary>
        [JsonProperty("term_url")]
        public string TermUrl { get; set; }
    }
}

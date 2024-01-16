using Newtonsoft.Json;

namespace RuRuServer.Models
{
    /// <summary>
    /// Настройки электронных чеков
    /// </summary>
    public class ChequeSettings
    {
        /// <summary>
        /// Данные покупателя (клиента) для электронного чека (передаются, если в электронных чеках по платежам нужно показывать блок с данными покупателя)
        /// </summary>
        [JsonProperty("customer")]
        public CustomerChequeData Customer { get; set; }

        /// <summary>
        /// Адрес электронной почты, на который должен быть отправлен электронный чек(и)
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

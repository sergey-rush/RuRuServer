using Newtonsoft.Json;

namespace RuRuServer.Models
{
    /// <summary>
    /// Данные покупателя (клиента) для электронного чека
    /// </summary>
    public class CustomerChequeData
    {
        /// <summary>
        /// ИНН
        /// </summary>
        [JsonProperty("inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Наименование(ФИО полностью или сокращённо)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Паспорт РФ (если указан, то непустая строка в любом формате)
        /// </summary>
        [JsonProperty("passport")]
        public string Passport { get; set; }
    }
}

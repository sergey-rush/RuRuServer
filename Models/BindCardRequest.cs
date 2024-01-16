using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RuRuServer.Models
{
    /// <summary>
    /// Запрос на привязку банковской карты
    /// </summary>
    public class BindCardRequest
    {
        /// <summary>
        /// Параметры для осуществления платежа по подписке
        /// </summary>
        [JsonProperty("card_data")]
        public CardData CardData { get; set; }

        /// <summary>
        /// Дополнительные данные для привязки:
        /// card_token - если данные вводились на странице API
        /// transaction_id - если необходима привязка по транзакции
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Описание привязки счёта
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Название привязки счёта
        /// </summary>
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Персональные данные
        /// </summary>
        [JsonProperty("personal_data")]
        public Dictionary<int, string> PersonalData { get; set; }

        /// <summary>
        /// Приоритет привязанного счёта,
        /// 1 - если приоритет не назначен
        /// </summary>
        [JsonProperty("priority")]
        [Required]
        public int Priority { get; set; }

        /// <summary>
        /// Схема привязки:
        /// 1 - без подтверждения
        /// 2 - с подтверждением через 3DS
        /// 4 - с подтверждением контрольной суммы
        /// 6 - с прохождением 3ds и подтверждением контрольной суммы
        /// 8 - привязка по транзакции
        /// Допускается комбинация схем привязки
        /// </summary>
        [JsonProperty("schema")]
        public int Schema { get; set; }

        /// <summary>
        /// URL для возврата после авторизации платежа пользователем при использовании 3-D Secure или других подобных механизмов
        /// </summary>
        [JsonProperty("term_url")]
        public string TermUrl { get; set; }
    }
}

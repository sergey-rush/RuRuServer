using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RuRuServer.Models
{
    /// <summary>
    /// Результат привязки банковской карты
    /// </summary>
    public class BindCardResponse
    {
        /// <summary>
        /// Идентификатор карты
        /// </summary>
        [JsonProperty("account_id")]
        [Required]
        public int AccountId { get; set; }

        /// <summary>
        /// Данные для прохождения 3-D Secure
        /// </summary>
        [JsonProperty("confirm_data")]
        public ConfirmData ConfirmData { get; set; }

        /// <summary>
        /// Url, который нужно открыть в браузере для подтверждения привязки (например, через прохождение 3-D Secure)
        /// </summary>
        [JsonProperty("confirm_url")]
        public string ConfirmUrl { get; set; }

        /// <summary>
        /// Статус счёта:
        /// 0 - Активен
        /// 1 - требуется подтверждение контрольным кодом
        /// 2 - требуется подтверждение 3-D Secure
        /// 3 - Заблокирован
        /// 4 - Недоступно для использования
        /// </summary>
        [JsonProperty("state")]
        [Required]
        public int State { get; set; }
    }
}

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RuRuServer.Models
{
    /// <summary>
    /// Ответ с информацией о созданной подписке
    /// </summary>
    public class SubscriptionCreateResponse
    {
        /// <summary>
        /// Идентификатор созданной подписки
        /// </summary>
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Результат привязки банковской карты
        /// </summary>
        [JsonPropertyName("bind_card_response")]
        public BindCardResponse BindCardResponse { get; set; }

        /// <summary>
        /// Причина изменения статуса подписки, которая будет указана в подписке после успешного выполнения действия,
        /// инициированного сразу после её создания
        /// </summary>
        [JsonPropertyName("awaited_state_reason")]
        public int AwaitedStateReason { get; set; }
    }
}

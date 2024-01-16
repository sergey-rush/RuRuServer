using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RuRuServer.Models
{
    /// <summary>
    /// Запрос на получение маркеров доступа и обновления
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// Идентификатор приложения
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Пароль приложения
        /// </summary>
        //[JsonProperty("client_secret")]
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Пароль приложения
        /// </summary>
        [Required]
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        /// <summary>
        /// Маркер обновления
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Список областей действия маркера доступа через запятую
        /// </summary>
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}

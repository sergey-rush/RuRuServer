using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RuRuServer.Models
{
    /// <summary>
    /// Маркер доступа и обновления
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Маркер доступа
        /// </summary>
        [JsonPropertyName("access_token")]
        [Required]
        public string AccessToken { get; set; }

        /// <summary>
        /// Количество секунд до окончания срока действия маркера доступа
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Маркер обновления
        /// </summary>
        [JsonPropertyName("refresh_token")]
        [Required]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Тип маркера доступа
        /// </summary>
        [JsonPropertyName("token_type")]
        [Required]
        public string TokenType { get; set; }
    }
}

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RuRuServer.Models
{
    /// <summary>
    /// Пара (ключ, значение)
    /// </summary>
    public class KeyValueItem
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        [JsonProperty("Key")]
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        [JsonProperty("Value")]
        [Required]
        public string Value { get; set; }
    }
}

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
        [JsonProperty("key")]
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        [JsonProperty("value")]
        [Required]
        public string Value { get; set; }
    }
}

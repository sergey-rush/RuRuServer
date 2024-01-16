using Newtonsoft.Json;

namespace RuRuServer.Models
{
    /// <summary>
    /// Период (от и до)
    /// </summary>
    public class Period
    {
        /// <summary>
        /// Дата и время начала периода
        /// </summary>
        [JsonProperty("from")]
        public DateTime From { get; set; }

        /// <summary>
        /// Дата и время окончания периода
        /// </summary>
        [JsonProperty("to")]
        public DateTime To { get; set; }
    }
}

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RuRuServer.Models
{
    /// <summary>
    /// Запрос на создание подписки
    /// </summary>
    public class SubscriptionCreateRequest
    {
        /// <summary>
        /// Параметры для осуществления платежа по подписке
        /// </summary>
        [JsonPropertyName("additional_params")]
        public List<KeyValuePair<string, string>> AdditionalParams { get; set; } = new();

        /// <summary>
        /// Сумма платежа
        /// </summary>
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        /// <summary>
        /// Запрос на привязку банковской карты
        /// </summary>
        [JsonPropertyName("bind_card_request")]
        public BindCardRequest? BindCardRequest { get; set; }

        /// <summary>
        /// Требуется ли чекоящик (автоматически создаваемый ящик электронной почты для писем с информацией об электронных чеках) или нет:
        /// false - не требуется
        /// true - требуется
        /// </summary>
        [JsonPropertyName("cheque_email_required")]
        public bool? ChequeEmailRequired { get; set; }

        /// <summary>
        /// Настройки электронных чеков
        /// </summary>
        [JsonPropertyName("cheques")]
        public ChequeSettings? Cheques { get; set; }

        /// <summary>
        /// Дата и время платежа в вызывающей системе, на основании которого создаётся подписка
        /// </summary>
        [JsonPropertyName("external_transaction_created")]
        public string? ExternalTransactionCreated { get; set; }

        /// <summary>
        /// Идентификатор платежа в вызывающей системе, на основании которого создаётся подписка
        /// </summary>
        [JsonPropertyName("external_transaction_id")]
        public string? ExternalTransactionId { get; set; }

        /// <summary>
        /// Идентификатор подписки
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Пользователь принял все необходимые оферты
        /// </summary>
        [JsonPropertyName("offers_accepted")]
        [Required]
        public bool? OffersAccepted { get; set; }

        /// <summary>
        /// Период действия подписки
        /// </summary>
        [JsonPropertyName("period")]
        public Period? Period { get; set; }

        /// <summary>
        /// Телефонный номер пользователя, через который пользователь и система подписок могут взаимодействовать посредством СМС
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Количество продлений подписки
        /// </summary>
        [JsonPropertyName("prolongation_number")]
        public int ProlongationNumber { get; set; }

        /// <summary>
        /// Расписание в формате Cron (можно использовать http://www.cronmaker.com)
        /// </summary>
        [JsonPropertyName("schedule")]
        public string? Schedule { get; set; }

        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        [JsonPropertyName("service_id")]
        [Required]
        public int ServiceId { get; set; }

        /// <summary>
        /// Параметры для СМСуведомлений об операциях по подписке
        /// </summary>
        [JsonPropertyName("sms_params")]
        public List<KeyValuePair<string, string>> SmsParams { get; set; } = new ();

        /// <summary>
        /// Дата и время окончания пробного периода
        /// </summary>
        [JsonPropertyName("trial_period_end")]
        public string? TrialPeriodEnd { get; set; }

        /// <summary>
        /// Параметры для формирования ссылок на веб-страницы
        /// </summary>
        [JsonPropertyName("url_params")]
        public List<KeyValuePair<string, string>> UrlParams { get; set; } = new();

        /// <summary>
        /// Идентификатор пользователя в вызывающей системе
        /// </summary>
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }
    }
}

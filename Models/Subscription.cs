using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RuRuServer.Models
{
    /// <summary>
    /// Подписка
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Идентификатор подписки
        /// </summary>
        [JsonProperty("id")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор счёта (привязанной банковской карты)
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Параметры для осуществления платежа по подписке
        /// </summary>
        [JsonProperty("additional_params")]
        public Dictionary<string, string>[] AdditionalParams { get; set; }

        /// <summary>
        /// Дата и время следующего платежа по расписанию
        /// </summary>
        [JsonProperty("next_payment")]
        public DateTime NextPayment { get; set; }

        /// <summary>
        /// Дата и время последнего неуспешного платежа по подписке
        /// </summary>
        [JsonProperty("payment_failed")]
        public DateTime? PaymentFailed { get; set; }

        /// <summary>
        /// Количество успешных списаний
        /// </summary>
        [JsonProperty("payment_number")]
        [Required]
        public int PaymentNumber { get; set; }

        /// <summary>
        /// Дата и время последнего успешного платежа по подписке
        /// </summary>
        [JsonProperty("payment_succeeded")]
        public DateTime? PaymentSucceeded { get; set; }

        /// <summary>
        /// Период действия подписки
        /// </summary>
        [JsonProperty("period")]
        [Required]
        public Period Period { get; set; }

        /// <summary>
        /// Телефонный номер пользователя, через который пользователь и система подписок могут взаимодействовать посредством СМС. Также используется для списания средств
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Количество оставшихся продлений подписки
        /// </summary>
        [JsonProperty("prolongation_number")]
        [Required]
        public int ProlongationNumber { get; set; }

        /// <summary>
        /// Расписание в формате Cron (можно использовать http://www.cronmaker.com)
        /// </summary>
        [JsonProperty("schedule")]
        [Required]
        public string Schedule { get; set; }

        /// <summary>
        /// Параметры для СМС уведомлений об операциях по подписке
        /// </summary>
        [JsonProperty("sms_params")]
        public Dictionary<string, string>[] SmsParams { get; set; }

        /// <summary>
        /// Состояни подписки:
        /// 0 - неактивна
        /// 1 - активна
        /// </summary>
        [JsonProperty("state")]
        [Required]
        public int State { get; set; }

        /// <summary>
        /// Причина изменения состояния подписки:
        /// 0 - Подписка создана.Первый платёж запланирован
        /// 1 - Платёж находится в процессе совершения
        /// 2 - Платёж успешно совершён. Следующий платёж запланирован
        /// 3 - Списание не проведено
        /// 4 - Исчерпаны попытки списания средств в течение всех периодов
        /// 5 - Окончание срока подписки. Все предусмотренные подпиской платежи выполнены
        /// 6 - Отменена партнёром
        /// 7 - Отменена администратором
        /// 8 - Изменился оператор пользователя
        /// 9 - Первый платёж по подписке не удался
        /// 10 - Критическая ошибка платежа
        /// 11 - Подписка продлена. Первый платёж запланирован
        /// 12 - Окончание срока подписки. Все предусмотренные подпиской платежи выполнены. Подписка продлена
        /// 13 - Отменена из-за перевода привязки номера телефона к услуге в состояние "Аннулирована"
        /// 14 - Отменена пользователем через USSD
        /// 15 - Отменена пользователем через SMS
        /// 16 - Подписка создана. Ожидается подтверждение
        /// 17 - Подписка не подтверждена
        /// 18 - Исчерпаны попытки списания средств, но разрешено не деактивировать подписку
        /// 19 - Первый платёж по подписке не удался не из-за недостатка средств
        /// 20 - Отменена автоматически из-за большого срока, после последнего успешного платежа с номера телефона
        /// </summary>
        [JsonProperty("state_reason")]
        [Required]
        public int StateReason { get; set; }

        /// <summary>
        /// Дата и время последнего изменения состояния подписки
        /// </summary>
        [JsonProperty("state_updated")]
        [Required]
        public DateTime StateUpdated { get; set; }

        /// <summary>
        /// Общая сумма платежей по подписке в формате рубли.копейки
        /// </summary>
        [JsonProperty("total_payment_amount")]
        [Required]
        public float TotalPaymentAmount { get; set; }

        /// <summary>
        /// Код ошибки последней транзакции
        /// </summary>
        [JsonProperty("transaction_error")]
        public string TransactionError { get; set; }

        /// <summary>
        /// Идентификатор последней транзакции
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Дата и время окончания пробного периода
        /// </summary>
        [JsonProperty("trial_period_end")]
        public DateTime? TrialPeriodEnd { get; set; }

        /// <summary>
        /// Параметры для формирования ссылок на веб-страницы
        /// </summary>
        [JsonProperty("url_params")]
        public KeyValueItem UrlParams { get; set; }

        /// <summary>
        /// Идентификаторы пользователей в вызывающей системе, для которых действует подписка
        /// </summary>
        [JsonProperty("user_ids")]
        public KeyValueItem[] UserIds { get; set; }
    }
}

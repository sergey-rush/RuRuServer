using Newtonsoft.Json;

namespace RuRuServer.Models;

/// <summary>
/// CheckPaymentAvailRequest (CPAReq) PGA с магазином производится проверка возможности проведения платежа
/// </summary>
public class PaymentAvailModel
{
    /// <summary>
    /// merch_id - Идентификатор магазина в Сервисной платформе.
    /// </summary>
    [JsonProperty("merch_id")]
    public string MerchantId { get; set; }

    /// <summary>
    /// trx_id - Идентификатор транзакции в Сервисной платформе
    /// </summary>
    [JsonProperty("trx_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// Язык платёжной страницы (двухсимвольный код в соответствии со стандартом ISO 639).
    /// </summary>
    [JsonProperty("lang_code")]
    public string LangCode { get; set; }

    /// <summary>
    /// Набор параметров покупки string (128)
    /// Параметр o.order_id является обязательным
    /// </summary>
    [JsonProperty("o.order_id")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// Дата выполнения запроса в формате «yyyyMMdd HH:mm:ss».
    /// </summary>
    [JsonProperty("ts")]
    public string TimeStamp { get; set; }
}
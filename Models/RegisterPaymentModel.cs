using Newtonsoft.Json;
using RuRuServer.Extensions;

namespace RuRuServer.Models;

/// <summary>
/// Для регистрации результата платежа PGA отправляет в магазин GET запрос RegisterPaymentRequest (RPReq)
/// </summary>
public class RegisterPaymentModel : PaymentAvailModel
{
    /// <summary>
    /// merchant_trx - Идентификатор транзакции в системе магазина, полученный в CPARes (если магазин передал данный параметр).
    /// Рекомендуется использовать данный параметр для упрощения взаимодействия со службой поддержки. 
    /// </summary>
    [JsonProperty("merchant_trx")]
    public string PaymentId { get; set; }

    /// <summary>
    /// Результат платежа:
    ///	1 - Успешный
    ///	2 - Неуспешный
    /// </summary>
    [JsonProperty("result_code")]
    public string ResultCode { get; set; }

    /// <summary>
    /// Расширенный код завершения транзакции.
    /// Присутствует в случае, если result_code = 2
    /// </summary>
    [JsonProperty("ext_result_code")]
    public string ExtResultCode { get; set; }

    [JsonProperty("amount")]
    public string Amount { get; set; }

    /// <summary>
    /// p.rrn - Идентификатор платежа в ПЦ банка-эквайера string (40)
    /// Обязательно присутствует для успешной платёжной транзакции. В остальных случаях может отсутствовать.
    /// В платежах СБП PGA не отправляет авторизационный запрос в процессинговый центр банка, поэтому в случае СБП параметр отсутствует.
    /// </summary>
    [JsonProperty("p.rrn")]
    public string ChannelTransactionId { get; set; }

    [JsonProperty("p.authcode")]
    public string AuthCode { get; set; }

    [JsonProperty("p.maskedPan")]
    public string MaskedPan { get; set; }

    [JsonProperty("p.isFullyAuthenticated")]
    public string IsAuthenticated { get; set; }

    [JsonProperty("p.transmissionDateTime")]
    public string TransmissionDateTime { get; set; }

    /// <summary>
    /// ЭЦП банка эквайера в формате PEM (кодировано с помощью Base64).
    /// Алгоритм подписи - SHA1withRSA.
    /// Подписывается сформированный URL, начиная c “https://” (включительно) и до “&signature=” (не включая “&signature=”).
    /// </summary>
    [JsonProperty("signature")]
    public string Signature { get; set; }

    [JsonIgnore]
    public Uri Uri { get; set; }

    /// <summary>
    /// Дата и время выполнения запроса
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset PaymentTime
    {
        get
        {
            if (string.IsNullOrEmpty(TransmissionDateTime))
            {
                return TimeStamp.ToDateTimeOffset();
            }
            else
            {
                return TransmissionDateTime.ToDateTimeOffset();
            }
        }
    }
}
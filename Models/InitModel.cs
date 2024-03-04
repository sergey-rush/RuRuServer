﻿using Newtonsoft.Json;

namespace RuRuServer.Models;

public class InitModel
{
    [JsonProperty("lang_code")]
    public string LangCode { get; set; }

    /// <summary>
    /// merch_id - Идентификатор магазина в Сервисной платформе.
    /// </summary>
    [JsonProperty("merch_id")]
    public string MerchantId { get; set; }

    /// <summary>
    /// Набор параметров покупки string (128)
    /// Параметр o.order_id является обязательным
    /// </summary>
    [JsonProperty("o.order_id")]
    public string InvoiceId { get; set; }

    [JsonProperty("back_url_s")]
    public string SuccessUrl { get; set; }

    [JsonProperty("back_url_f")]
    public string FailureUrl { get; set; }

}
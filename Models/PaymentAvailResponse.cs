using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RuRuServer.Models;

[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot("payment-avail-response", Namespace = "", IsNullable = false)]
public class PaymentAvailResponse
{
    /// <summary>
    /// merchant-trx - Идентификатор транзакции в системе магазина string (50)
    /// Рекомендуется использовать данный параметр для упрощения взаимодействия со службой поддержки.
    /// </summary>
    [XmlElement("merchant-trx")]
    public string PaymentId { get; set; }


    /// <summary>
    /// Имя подмагазина. string(40) Допустимые символы: A-Za-z 0-9.,-
    /// Если параметр присутствует, то в качестве итогового имени магазина используется значение вида: «имя магазина-посредника» + «*» + «имя подмагазина»
    /// </summary>
    [XmlElement("submerchant")]
    public string SubMerchant { get; set; }

    /// <summary>
    /// YN
    /// </summary>
    [XmlElement("addCardAllowed")]
    public string AddCardAllowed { get; set; }

    /// <summary>
    /// CardRegister|Payment|AFT|OCT|P2P
    /// </summary>
    [XmlElement("transaction-type")]
    public string TransactionType { get; set; }

    [XmlElement]
    public string RegisterRecurrent { get; set; }

    [XmlElement("card")]
    public Card Card { get; set; }

    /// <summary>
    /// Описание покупки. Заполняется в случае, если result.сode=1.
    /// </summary>
    [XmlElement("purchase")]
    public Purchase Purchase { get; set; }

    [XmlArray("order-params")]
    [XmlArrayItem("param", typeof(OrderItem), IsNullable = false)]
    public List<OrderItem> OrderItemList { get; set; }

    [XmlElement("primaryTrxPcid")]
    public string PrimaryTrxPcid { get; set; }

    [XmlElement("result")]
    public Result Result { get; set; }
}

/// <summary>
/// 1.4. Магазин возвращает в PGA ответ о возможности проведения операции (CPARes).
/// Ответ содержит идентификатор ранее зарегистрированной карты с указанием типа операции (card.present=Y) и дополнительные атрибуты. 
/// </summary>
[Serializable]
[XmlType(AnonymousType = true)]// "card",
public class Card
{
    [XmlElement("id")]
    public string Id { get; set; }

    [XmlElement("trx-id")]
    public string TrxId { get; set; }

    [XmlElement("ref")]
    public string Ref { get; set; }

    [XmlElement("present")]
    public string Present { get; set; }
}

/// <summary>
/// Описание покупки. Заполняется в случае, если result.сode=1.
/// </summary>
[Serializable]
[XmlType(AnonymousType = true)]//"purchase",
public class Purchase
{
    /// <summary>
    /// Полное описание покупки string (125)
    /// </summary>
    [XmlElement("longDesc")]
    public string LongDesc { get; set; }

    /// <summary>
    /// Краткое описание покупки string (30)
    /// Если поле отсутствует, то в качестве краткого описания будет использовано полное описание, укороченное до 30-и символов.
    /// </summary>
    [XmlElement("shortDesc")]
    public string ShortDesc { get; set; }

    [XmlElement("account-amount")]
    public AccountAmount AccountAmount { get; set; }

    [XmlArray("items")]
    [XmlArrayItem("item", typeof(PurchaseItem), IsNullable = false)]
    public List<PurchaseItem> PurchaseItemList { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]// "account-amount",
public class AccountAmount
{
    [XmlElement("id")]
    public string Id { get; set; }

    /// <summary>
    /// Сумма платежа в минорных единицах integer (18)
    /// </summary>
    [XmlElement("amount")]
    public long Amount { get; set; }

    [XmlElement("fee")]
    public long Fee { get; set; }

    /// <summary>
    /// Трехзначный integer(3) цифровой код валюты (ISO 4217) 
    /// </summary>
    [XmlElement("currency")]
    public int Currency { get; set; }

    [XmlElement("exponent")]
    public int Exponent { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]// "item", 
public class PurchaseItem
{
    [XmlAttribute("commission")]
    public long Commission { get; set; }

    [XmlAttribute("currency")]
    public string Currency { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("price")]
    public long Price { get; set; }

    [XmlAttribute("quantity")]
    public int Quantity { get; set; }

    [XmlAttribute("sum")]
    public long Sum { get; set; }

    [XmlElement("field")]
    public List<Field> FieldList { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]//"field",
public class Field
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("value")]
    public string Value { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
public class OrderItem
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("value")]
    public string Value { get; set; }
}

/// <summary>
/// Результат операции
/// </summary>
[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "result", Namespace = "", IsNullable = false)]
public class Result
{
    /// <summary>
    /// Результат integer(1) проверки возможности платежа:
    ///	1 - результат успешный;
    ///	2 - результат неуспешный.
    /// WARNING: Магазин должен отправить в ответе на запрос регистрации платежа result.сode=1,
    /// если платеж не был успешным, но его результат зарегистрирован магазином.
    /// </summary>
    [XmlElement(ElementName = "code")]
    public int Code { get; set; }

    /// <summary>
    /// Описание результата проверки возможности платежа string (125)
    /// Рекомендуется заполнять идентификатором транзакции, заказа и корзины в системе магазина для разрешения возможных спорных ситуаций в случае их возникновения.
    /// </summary>
    [XmlElement(ElementName = "desc")]
    public string Desc { get; set; }
}

[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot("register-payment-response", Namespace = "", IsNullable = false)]
public class RegisterPaymentResponse
{
    [XmlElement("result")]
    public Result Result { get; set; }
}

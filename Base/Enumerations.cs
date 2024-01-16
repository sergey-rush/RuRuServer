namespace RuRuServer.Base;

/// <summary>
/// Причина изменения состояния подписки:
/// </summary>
public enum StateReason
{
    /// <summary>
    /// 0 - Подписка создана. Первый платёж запланирован
    /// </summary>
    SubscriptionCreated = 0,

    /// <summary>
    /// 1 - Платёж находится в процессе совершения
    /// </summary>
    PaymentInProgress = 1,

    /// <summary>
    /// 2 - Платёж успешно совершён. Следующий платёж запланирован
    /// </summary>
    PaymentCompleted = 2,

    /// <summary>
    /// 3 - Списание не проведено
    /// </summary>
    FundsNotWithdrawn = 3,

    /// <summary>
    ///  4 - Исчерпаны попытки списания средств в течение всех периодов
    /// </summary>
    NumAttemptExceeded = 4,

    /// <summary>
    /// 5 - Окончание срока подписки. Все предусмотренные подпиской платежи выполнены
    /// </summary>
    SubscriptionExpired = 5,

    /// <summary>
    /// 6 - Отменена партнёром
    /// </summary>
    CanceledByPartner = 6,

    /// <summary>
    /// 7 - Отменена администратором
    /// </summary>
    CanceledByAdmin = 7,

    /// <summary>
    /// 8 - Изменился оператор пользователя
    /// </summary>
    UserOperatorChanged = 8,

    /// <summary>
    /// 9 - Первый платёж по подписке не удался
    /// </summary>
    FirstPaymentFailed = 9,

    /// <summary>
    /// 10 - Критическая ошибка платежа
    /// </summary>
    FatalPaymentError = 10,

    /// <summary>
    /// 11 - Подписка продлена. Первый платёж запланирован
    /// </summary>
    SubscriptionExtended = 11,

    /// <summary>
    /// 12 - Окончание срока подписки. Все предусмотренные подпиской платежи выполнены. Подписка продлена
    /// </summary>
    ExpiredAndExtended = 12,

    /// <summary>
    /// 13 - Отменена из-за перевода привязки номера телефона к услуге в состояние "Аннулирована"
    /// </summary>
    BindingRejected = 13,

    /// <summary>
    /// 14 - Отменена пользователем через USSD
    /// </summary>
    CanceledByUserUSSD = 14,

    /// <summary>
    /// 15 - Отменена пользователем через SMS
    /// </summary>
    CanceledByUserSMS = 15,

    /// <summary>
    /// 16 - Подписка создана. Ожидается подтверждение
    /// </summary>
    CreatedConfirmationAwait = 16,

    /// <summary>
    /// 17 - Подписка не подтверждена
    /// </summary>
    SubscriptionUnconfirmed = 17,

    /// <summary>
    /// 18 - Исчерпаны попытки списания средств, но разрешено не деактивировать подписку
    /// </summary>
    NumAttemptPayoutExceeded = 18,

    /// <summary>
    /// 19 - Первый платёж по подписке не удался не из-за недостатка средств
    /// </summary>
    FirstPaymentFailedNoFunds = 19,

    /// <summary>
    /// 20 - Отменена автоматически из-за большого срока, после последнего успешного платежа с номера телефона
    /// </summary>
    CanceledAfterPeriod = 20
}

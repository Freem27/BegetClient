namespace TDV.BegetClient.Enums
{
    public enum PayType
    {
        /// <summary>
        /// оплатить домен невозможно
        /// </summary>
        UnableToPay,
        /// <summary>
        /// оплата будет со счета аккаунта
        /// </summary>
        Money,
        /// <summary>
        /// оплата будет за счет бонуса
        /// </summary>
        BonusDomain,
    }
}

using System.Text.Json.Serialization;
using TDV.BegetClient.Enums;

namespace TDV.BegetClient.Models.Domain
{
    public class CheckDomainToRegisterResponse
    {
        /// <summary>
        /// свободен ли домен для регистрации 
        /// (на основании сервиса WHOIS)
        /// </summary>
        [JsonPropertyName("may_be_registered")]
        public bool MayBeRegistered { get; set; }
        /// <summary>
        /// текущее количество бонусных доменов 
        /// на аккаунте в выбранной зоне
        /// </summary>
        [JsonPropertyName("bonus_domains")]
        public int BonusDomains { get; set; }
        /// <summary>
        /// текущий баланс аккаунта
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// способ оплаты регистрации домена
        /// </summary>
        [JsonConverter(typeof(PayTypeConverter))]
        [JsonPropertyName("pay_type")]
        public PayType PayType { get; set; }
        /// <summary>
        /// итоговая стоимость регистрации домена 
        /// (с учетом периода)
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// находится ли уже такой домен
        /// на обслуживании BeGet
        /// </summary>
        [JsonPropertyName("in_system")]
        public bool InSystem { get; set; }
    }
}

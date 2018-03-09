using Newtonsoft.Json;

namespace XyAuto.It.MultiTenancy.Payments.Paypal
{
    public class PayPalAccessTokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}

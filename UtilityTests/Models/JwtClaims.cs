using Newtonsoft.Json;

namespace NetCodeUtility_SampleTests.Models;

internal class JwtCustClaims
{
    [JsonProperty(PropertyName = "user_id")]
    public uint UserId { get; set; }
}
using Newtonsoft.Json;

namespace FkUtilityTests.Models;

internal class JwtCustClaims
{
    [JsonProperty(PropertyName = "user_id")]
    public uint UserId { get; set; }
}
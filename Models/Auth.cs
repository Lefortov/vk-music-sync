using System;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Auth
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token{get;set;}

        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn{get;set;}

        [JsonProperty(PropertyName = "user_id")]
        public long UserId{get;set;}
    }
}

using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class AudioResponse
    {
        [JsonProperty(PropertyName = "count")]
        public long Count{get;set;}

        [JsonProperty(PropertyName = "items")]
        public List<Audio> Audios{get;set;}
    }
}

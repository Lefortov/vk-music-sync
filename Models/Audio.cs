using System;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Audio
    {
        [JsonProperty(PropertyName = "id")]
        public long Id{get;set;}

        [JsonProperty(PropertyName = "owner_id")]
        public long OwnderId{get;set;}

        [JsonProperty(PropertyName = "artist")]        
        public string Artist{get;set;}

        [JsonProperty(PropertyName = "title")]                
        public string Title{get;set;}

        [JsonProperty(PropertyName = "duration")]
        public int Duration{get;set;}
        
        [JsonProperty(PropertyName = "date")]        
        public long Date{get;set;}

        [JsonProperty(PropertyName = "url")]        
        public string Url{get;set;}

        [JsonProperty(PropertyName = "lyrics_id")]        
        public long LyricsId{get;set;}

        [JsonProperty(PropertyName = "genre_id")]        
        public int GenreId{get;set;}
    }
}

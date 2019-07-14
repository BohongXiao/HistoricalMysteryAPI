using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HistoricalMysteryAPI.Contracts
{
    public class ArticleContent
    {
        [JsonProperty]
        public int ArticleContentId { get; set; }

        [JsonProperty]
        public int ArticleId { get; set; }

        [JsonProperty]
        public int ParagraphNumber { get; set; }

        [JsonProperty]
        public string ParagraphEmbedContent { get; set; }
    }
}

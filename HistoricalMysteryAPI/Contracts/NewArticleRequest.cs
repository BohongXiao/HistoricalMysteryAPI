using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HistoricalMysteryAPI.Contracts
{
    public class NewArticleRequest
    {
        [JsonProperty]
        public int ArticleAuthorId { get; set; }

        [JsonProperty]
        public int ArticleCollectionId { get; set; }

        [JsonProperty]
        public string ArticleTag { get; set; }

        [JsonProperty]
        public string ArticleFeatureImage { get; set; }

        [JsonProperty]
        public string ArticleDisplayTitle { get; set; }

        [JsonProperty]
        public string ArticleDisplaySubtitle { get; set; }

        [JsonProperty]
        public DateTime ArticleUpdateTime { get; set; }

        [JsonProperty]
        public int ArticleReadTime { get; set; }

        [JsonProperty]
        public NewArticleContentRequest[] ArticleContent { get; set; }
    }
}

using Newtonsoft.Json;

namespace HM.Models
{
    public class ArticleItem
    {
        [JsonProperty]
        int ArticleId { get; set; }

        [JsonProperty]
        UserItem ArticleAuthor { get; set; }

        [JsonProperty]
        int ArticleCollectionId { get; set; }

        [JsonProperty]
        string ArticleTag { get; set; }

        [JsonProperty]
        string ArticleFeatureImage { get; set; }

        [JsonProperty]
        string ArticleDisplayTitle { get; set; }

        [JsonProperty]
        string ArticleDisplaySubtitle { get; set; }

        [JsonProperty]
        ArticleContentItem[] ArticleContent { get; set; }
    }
}

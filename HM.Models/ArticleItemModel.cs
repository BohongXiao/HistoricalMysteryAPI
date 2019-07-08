namespace HM.Models
{
    public class ArticleItemModel
    {
        public int ArticleId { get; set; }

        public UserItem ArticleAuthor { get; set; }

        public int ArticleCollectionId { get; set; }

        public string ArticleTag { get; set; }

        public string ArticleFeatureImage { get; set; }

        public string ArticleDisplayTitle { get; set; }

        public string ArticleDisplaySubtitle { get; set; }

        public ArticleContentItem[] ArticleContent { get; set; }
    }
}

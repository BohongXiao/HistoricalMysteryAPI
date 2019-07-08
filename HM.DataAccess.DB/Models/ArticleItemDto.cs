
namespace HM.DataAccess.DB.Models
{
    public class ArticleItemDto
    {
        public int ArticleId { get; set; }

        public int ArticleAuthorId { get; set; }

        public int ArticleCollectionId { get; set; }

        public string ArticleTag { get; set; }

        public string ArticleFeatureImage { get; set; }

        public string ArticleDisplayTitle { get; set; }

        public string ArticleDisplaySubtitle { get; set; }

    }
}

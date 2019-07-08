namespace HM.Models
{
    public class ArticleContentItem
    {
        int ArticleContentId { get; set; }

        int ArticleId { get; set; }

        int ParagraphNumber { get; set; }

        private string ParagraphEmbedContent { get; set; }
    }
}
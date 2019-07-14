
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime ArticleUpdateTime { get; set; }

        public int ArticleReadTime { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

    }
}

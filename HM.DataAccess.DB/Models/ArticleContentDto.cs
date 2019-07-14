using System;
using System.Collections.Generic;
using System.Text;

namespace HM.DataAccess.DB.Models
{
    public class ArticleContentDto
    {
        public int ArticleContentId { get; set; }

        public int ArticleId { get; set; }

        public int ParagraphNumber { get; set; }

        public string ParagraphEmbedContent { get; set; }
    }
}

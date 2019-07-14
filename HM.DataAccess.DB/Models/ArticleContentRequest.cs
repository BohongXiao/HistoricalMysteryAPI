using System;
using System.Collections.Generic;
using System.Text;

namespace HM.DataAccess.DB.Models
{
    public class ArticleContentRequest
    {
        public int ParagraphNumber { get; set; }

        public string ParagraphEmbedContent { get; set; }
    }
}

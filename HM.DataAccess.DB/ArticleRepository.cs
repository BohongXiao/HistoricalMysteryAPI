using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using HM.DataAccess.DB.Models;
using Microsoft.Extensions.Configuration;

namespace HM.DataAccess.DB
{
    public class ArticleRepository: BaseRepository, IArticleRepository
    {
        private readonly IConfiguration _config;

        public ArticleRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<ArticleItemDto>> GetAllArticles()
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"
                    SELECT ma.ArticleId,
	                    ma.ArticleDisplayTitle,
	                    ma.ArticleDisplaySubtitle,
	                    ma.ArticleFeatureImage,
	                    ma.ArticleUpdateTime,
	                    ma.ArticleReadTime,
	                    mu.UserFirstName,
	                    mu.UserLastName
                    FROM .HM.Medium_Article ma
                    JOIN .HM.Medium_User mu
	                    ON ma.ArticleAuthorId = mu.UserId";
                var result = await connection.QueryAsync<ArticleItemDto>(sQuery);
                return result;
            }
        }

        public async Task<ArticleItemDto> GetArticleById(int id)
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"
                    SELECT ma.ArticleId,
	                    ma.ArticleDisplayTitle,
	                    ma.ArticleDisplaySubtitle,
	                    ma.ArticleFeatureImage,
	                    ma.ArticleUpdateTime,
	                    ma.ArticleReadTime,
	                    mu.UserFirstName,
	                    mu.UserLastName
                    FROM .HM.Medium_Article ma
                    JOIN .HM.Medium_User mu
	                    ON ma.ArticleAuthorId = mu.UserId
                    WHERE ma.ArticleId = @articleId";
                var result = await connection.QuerySingleAsync<ArticleItemDto>(sQuery, new {articleId=id});
                return result;
            }
        }

        public async Task<IEnumerable<ArticleItemDto>> GetHeroArticle()
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"
                    SELECT TOP 5 ma.ArticleId,
	                    ma.ArticleDisplayTitle,
	                    ma.ArticleDisplaySubtitle,
	                    ma.ArticleFeatureImage,
	                    ma.ArticleUpdateTime,
	                    ma.ArticleReadTime,
	                    mu.UserFirstName,
	                    mu.UserLastName
                    FROM .HM.Medium_Article ma
                    JOIN .HM.Medium_User mu
	                    ON ma.ArticleAuthorId = mu.UserId
                    ORDER BY ma.ArticleId DESC";
                var result = await connection.QueryAsync<ArticleItemDto>(sQuery);
                return result;
            }
        }

        public async Task<IEnumerable<ArticleItemDto>> GetFeatureArticle()
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"
                    SELECT ma.ArticleId,
	                    ma.ArticleDisplayTitle,
	                    ma.ArticleDisplaySubtitle,
	                    ma.ArticleFeatureImage,
	                    ma.ArticleUpdateTime,
	                    ma.ArticleReadTime,
	                    mu.UserFirstName,
	                    mu.UserLastName
                    FROM .HM.Medium_Article ma
                    JOIN .HM.Medium_User mu
	                    ON ma.ArticleAuthorId = mu.UserId
                    ORDER BY ma.ArticleId DESC
                    OFFSET 5 ROWS FETCH NEXT 15 ROWS ONLY";
                var result = await connection.QueryAsync<ArticleItemDto>(sQuery);
                return result;
            }
        }

        public async Task<IEnumerable<ArticleContentDto>> GetArticleContent(int articleId)
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"
                    SELECT mac.ArticleId, 
	                    mac.ParagraphNumber, 
	                    mac.ParagraphEmbedContent
                    FROM .HM.Medium_Article_Content mac
                    WHERE mac.ArticleId = @articleId
                    ORDER BY mac.ParagraphNumber";
                IEnumerable<ArticleContentDto> result = await connection.QueryAsync<ArticleContentDto>(sQuery, new { articleId = articleId });
                return result;
            }
        }

        public async Task<int> SaveArticleRecord(int userId, string articleFeatureImage, string articleTitle, string articleSubTitle, ArticleContentRequest[] articleContent)
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userId", userId);
                parameters.Add("@articleFeatureImage", articleFeatureImage);
                parameters.Add("@articleTitle", articleTitle);
                parameters.Add("@articleSubTitle", articleSubTitle);
                DataTable articleContentParam = new DataTable("HM.ArticleContent");
                articleContentParam.Columns.Add("ParagraphNumber", typeof(int));
                articleContentParam.Columns.Add("ParagraphEmbedContent", typeof(string));
                foreach (ArticleContentRequest contentRequest in articleContent)
                {
                    articleContentParam.Rows.Add(contentRequest.ParagraphNumber, contentRequest.ParagraphEmbedContent);
                }
                parameters.Add("@articleContent", articleContentParam.AsTableValuedParameter("HM.ArticleContent"));
                parameters.Add("@articleId", dbType:DbType.Int32, direction:ParameterDirection.Output);
                string sQuery = @".hm.sp_HM_RW_SaveNewArticle";
                try
                {
                    var result = await connection.QueryAsync(sQuery, parameters, commandType: CommandType.StoredProcedure);
                    return parameters.Get<int>("articleId");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }
    }

    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleItemDto>> GetAllArticles();

        Task<ArticleItemDto> GetArticleById(int id);

        Task<IEnumerable<ArticleItemDto>> GetHeroArticle();

        Task<IEnumerable<ArticleItemDto>> GetFeatureArticle();

        Task<IEnumerable<ArticleContentDto>> GetArticleContent(int articleId);

        Task<int> SaveArticleRecord(int userId, string articleFeatureImage, string articleTitle, string articleSubTitle,
            ArticleContentRequest[] articleContent);
    }
}

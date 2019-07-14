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
                string sQuery = $"SELECT ma.ArticleId, ma.ArticleStatus, ma.ArticleAuthorId, ma.ArticleTag, ma.ArticleDisplayTitle, ma.ArticleDisplaySubtitle, ma.ArticleFeaturedImage AS ArticleFeatureImage FROM .HM.Medium_Article ma";
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
                string sQuery = "SELECT ma.ArticleId, ma.ArticleStatus, ma.ArticleAuthorId, ma.ArticleTag, ma.ArticleDisplayTitle, ma.ArticleDisplaySubtitle, ma.ArticleFeaturedImage AS ArticleFeatureImage  FROM .HM.Medium_Article ma WHERE ArticleId = @articleId";
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
                string sQuery = "SELECT TOP 5 ma.ArticleId, ma.ArticleStatus, ma.ArticleAuthorId, ma.ArticleTag, ma.ArticleDisplayTitle, ma.ArticleDisplaySubtitle, ma.ArticleFeaturedImage AS ArticleFeatureImage  FROM .HM.Medium_Article ma ORDER BY ArticleId DESC";
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
                string sQuery = "SELECT ma.ArticleId, ma.ArticleStatus, ma.ArticleAuthorId, ma.ArticleTag, ma.ArticleDisplayTitle, ma.ArticleDisplaySubtitle, ma.ArticleFeaturedImage AS ArticleFeatureImage  FROM .HM.Medium_Article ma ORDER BY ArticleId DESC OFFSET 5 ROWS FETCH NEXT 15 ROWS ONLY";
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
                string sQuery = "SELECT * FROM .HM.Medium_Article_Content WHERE ArticleId = @articleId";
                IEnumerable<ArticleContentDto> result = await connection.QueryAsync<ArticleContentDto>(sQuery, new { articleId = articleId });
                return result;
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
    }
}

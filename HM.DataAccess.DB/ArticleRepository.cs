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
                string sQuery = "SELECT * FROM .HM.Medium_Article";
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
                string sQuery = "SELECT * FROM .HM.Medium_Article WHERE ArticleId = @articleId";
                var result = await connection.QuerySingleAsync<ArticleItemDto>(sQuery, new {articleId=id});
                return result;
            }
        }
    }

    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleItemDto>> GetAllArticles();

        Task<ArticleItemDto> GetArticleById(int id);
    }
}

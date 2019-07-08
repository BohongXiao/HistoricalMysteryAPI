using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HM.Models;
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

        public async Task<ArticleItem[]> GetAllArticles()
        {
            string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sQuery = "SELECT * FROM .HM.Medium_Article";
                var result = await connection.QueryAsync<ArticleItem>(sQuery);
                return result.ToArray();
            }
        }

        public Task<ArticleItem> GetArticleById(int id)
        {
            throw new NotImplementedException();
            //string connectionString = _config.GetValue<string>("ConnectionStrings:HMConnection");
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    string sQuery = "SELECT * FROM .HM.Medium_Article WHERE ArticleId = @id";
            //    var result = await connection.QueryAsync<ArticleItem>(sQuery, new {id: id} );
            //    return result.ToArray();
            //}
        }
    }

    public interface IArticleRepository
    {
        Task<ArticleItem[]> GetAllArticles();

        Task<ArticleItem> GetArticleById(int id);
    }
}

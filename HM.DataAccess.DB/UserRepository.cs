using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HM.DataAccess.DB.Models;
using Microsoft.Extensions.Configuration;

namespace HM.DataAccess.DB
{
    public class UserRepository : BaseRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<ArticleItemDto>> Get()
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
    }
}

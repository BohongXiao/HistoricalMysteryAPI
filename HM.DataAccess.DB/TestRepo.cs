using System.Collections.Generic;
using System.Threading.Tasks;
using HM.Interfaces.IRepositories;

namespace HM.DataAccess.DB
{
    public class TestRepo : BaseRepository, ITestRepo
    {
        public Task<IEnumerable<string>> GetAll()
        {
            var res = new List<string>
            {
                "Baron", "JinXin", "XiuWei", "XiuFeng", "Will"
            };
            return Task.FromResult<IEnumerable<string>>(res);
        }
    }
}
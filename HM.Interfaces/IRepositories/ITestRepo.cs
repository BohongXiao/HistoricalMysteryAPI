using System.Collections.Generic;
using System.Threading.Tasks;

namespace HM.Interfaces.IRepositories
{
    public interface ITestRepo
    {
        Task<IEnumerable<string>> GetAll();
    }
}

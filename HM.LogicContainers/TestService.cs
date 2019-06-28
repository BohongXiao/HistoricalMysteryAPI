using System.Threading.Tasks;
using HM.Common.Utils;
using HM.Interfaces.IRepositories;
using HM.Interfaces.IServices;
using HM.Interfaces.IUtils;

namespace HM.LogicContainers
{
    public class TestService : BaseService, ITestService
    {
        private readonly ITestRepo _repo;

        public TestService(ILoggingService log, ITestRepo repo) : base(log)
        {
            _repo = repo;
        }

        public async Task<string> TestAsync(string message)
        {
            var ppl = await _repo.GetAll().Caf();
            var people = string.Join(',', ppl);
            return $"These people: {people} {message}!";
        }
    }
}
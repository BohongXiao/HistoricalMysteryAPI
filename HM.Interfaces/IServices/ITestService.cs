using System.Threading.Tasks;

namespace HM.Interfaces.IServices
{
    public interface ITestService
    {
        Task<string> TestAsync(string message);
    }
}
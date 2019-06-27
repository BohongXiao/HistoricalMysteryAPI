using HM.Interfaces.IUtils;

namespace HM.LogicContainers
{
    public abstract class BaseService
    {
        protected readonly ILoggingService Log;

        protected BaseService(ILoggingService log) => Log = log;
    }
}
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HM.Common.Utils
{
    public static class ExtensionMethods
    {
        public static ConfiguredTaskAwaitable Caf(this Task task) => task.ConfigureAwait(false);
        public static ConfiguredTaskAwaitable<T> Caf<T>(this Task<T> task) => task.ConfigureAwait(false);
    }
}
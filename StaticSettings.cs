using System.Threading.Tasks;
using System.Threading;

namespace StaticSettings
{
    static class Options
    {
        public static CancellationTokenSource Token;
        public static bool active { get; set; } = false;
    }
}

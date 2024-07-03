using System.Reflection;

namespace WorkTimeTracking
{
    public sealed class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}

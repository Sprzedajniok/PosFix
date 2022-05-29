using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PosFix.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool EnableChecks { get; set; } = true;
        public virtual bool EnableFPFC { get; set; } = true;

        public virtual void OnReload()
        {
            /**/
        }

        public virtual void Changed()
        {
            /**/
        }

        public virtual void CopyFrom(PluginConfig other)
        {
            /**/
        }
    }
}
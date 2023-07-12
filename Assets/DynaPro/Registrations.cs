using Beamable;
using Beamable.Common.Dependencies;
using UnityEngine;

namespace DynaPro
{
    [BeamContextSystem]
    public class Registrations
    {
        [RegisterBeamableDependencies]
        public static void Register(IDependencyBuilder builder)
        {
            builder.AddSingleton<DynaProService>();
            builder.AddSingleton<DynaProSettings>(() =>
            {
                var settings = Resources.LoadAll<DynaProSettings>("");
                // var settings = Resources.Load<DynaProSettings>("Assets/DynaPro/Resources/DynaProSettings.asset");
                return settings[0];
            });
        }
    }

    public static class BeamContextExtensions
    {
        public static DynaProService DynaProService(this BeamContext ctx) =>
            ctx.ServiceProvider.GetService<DynaProService>();
    }
}
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Xenon.Common;

internal class XenonConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ServerSide;

	[Header("Gameplay")]

    [DefaultValue(true)]
    [ReloadRequired]
    public bool BasicProgressionChanges;

    [DefaultValue(false)] // This sets the config's default value.
	[ReloadRequired] // Marking it with [ReloadRequired] makes tModLoader force a mod reload if the option is changed. It should be used for things like item toggles, which only take effect during mod loading
	public bool RequirePreviousOreTierForNext;

    [DefaultValue(false)]
    [ReloadRequired]
    public bool MountainGenerationConfigEnabler;
}

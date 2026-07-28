using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Xenon.Common;

internal class XenonConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Header("Gameplay")]

	[DefaultValue(false)] // This sets the config's default value.
	[ReloadRequired] // Marking it with [ReloadRequired] makes tModLoader force a mod reload if the option is changed. It should be used for things like item toggles, which only take effect during mod loading
	public bool RequirePreviousOreTierForNext;

	[DefaultValue(true)]
	[ReloadRequired]
	public bool PickaxeRequiredForNextOreTier;

    [DefaultValue(false)]
    [ReloadRequired]
    public bool MountainGenerationConfigEnabler;

    [Header("Miscellaneous")]

    [DefaultValue(false)]
    [ReloadRequired]
    public bool HellstoneRename;
}

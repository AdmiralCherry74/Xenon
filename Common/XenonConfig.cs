using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Xenon.Common;

internal class XenonConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ClientSide;
	[Header("$Mods.Xenon.Config.ItemHeader")] // Headers are like titles in a config. You only need to declare a header on the item it should appear over, not every item in the category.
	[DefaultValue(false)] // This sets the configs default value.
	[ReloadRequired] // Marking it with [ReloadRequired] makes tModLoader force a mod reload if the option is changed. It should be used for things like item toggles, which only take effect during mod loading
	public bool RequirePreviousOreTierForNext;

	[DefaultValue(true)]
	[ReloadRequired]
	public bool PickaxeRequiredForNextOreTier;
}

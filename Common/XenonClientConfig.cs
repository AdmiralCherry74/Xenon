using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Xenon.Common;

internal class XenonClientConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("Miscellaneous")]

    [DefaultValue(false)]
    [ReloadRequired]
    public bool HellstoneRename;
}

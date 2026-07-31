using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.ModSupport.FargowiltasSouls;

[ExtendsFromMod("FargowiltasSouls")]
internal class FargowiltasSoulsSupportPlayer : ModPlayer
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.FargowiltasSoulsContentEnabled;
	}
}

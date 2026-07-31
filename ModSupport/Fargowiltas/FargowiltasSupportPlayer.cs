using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.ModSupport.Fargowiltas;

[ExtendsFromMod("Fargowiltas")]
internal class FargowiltasSupportPlayer : ModPlayer
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.FargowiltasContentEnabled;
	}
}

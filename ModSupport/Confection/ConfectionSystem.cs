using System;
using Terraria.ModLoader;
using Xenon.ModSupport.Confection.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone.Mossy;

namespace Xenon.ModSupport.Confection;

[ExtendsFromMod("TheConfectionRebirth")]
internal class ConfectionSystem : ModSystem
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return ModLoader.HasMod("TheConfectionRebirth");
	}
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		if (ModLoader.HasMod("TheConfectionRebirth"))
		{
			ModContent.GetInstance<TheConfectionRebirth.Biomes.ConfectionBiomeTileCount>().confectionBlockCount +=
				tileCounts[ModContent.TileType<CreamQuicksand>()] +
				tileCounts[ModContent.TileType<HestiaStone>()] +
				tileCounts[ModContent.TileType<MossyHestiaStone>()];
		}
	}
}

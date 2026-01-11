using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone.Mossy;

namespace Xenon.ModSupport;

internal class CompatTile : GlobalTile
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.AvalonContentEnabled && XenonMod.TheConfectionRebirthContentEnabled;
	}
	public override void SetStaticDefaults()
	{
		ModContent.GetInstance<JacarandaTree>().GrowsOnTileId =
		[
			ModContent.TileType<MossyOuranoStone>(),
			ModContent.TileType<MossyAresStone>(),
			ModContent.TileType<MossyNyxStone>(),
			ModContent.TileType<MossyHelioStone>(),
			ModContent.TileType<MossyHephStone>(),
			ModContent.TileType<MossyPolloStone>(),
			ModContent.TileType<MossyHestiaStone>(),
			ModContent.TileType<OuranoStone>(),
			ModContent.TileType<AresStone>(),
			ModContent.TileType<NyxStone>(),
			ModContent.TileType<HelioStone>(),
			ModContent.TileType<HephStone>(),
			ModContent.TileType<PolloStone>(),
			ModContent.TileType<HestiaStone>()
		];
	}
}

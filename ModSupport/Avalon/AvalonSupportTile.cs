using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Stone.Mossy;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Avalon.Content.Tiles;

namespace Xenon.ModSupport.Avalon;

internal class AvalonSupportTile : GlobalTile
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.AvalonContentEnabled;
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
			ModContent.TileType<OuranoStone>(),
			ModContent.TileType<AresStone>(),
			ModContent.TileType<NyxStone>(),
			ModContent.TileType<HelioStone>(),
			ModContent.TileType<HephStone>(),
			ModContent.TileType<PolloStone>()
		];
	}
}

using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Stone;

namespace Xenon.Common.Data;

internal class TileSets
{
	public static bool[] MountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<OuranoStone>(),
		ModContent.TileType<NyxStone>(),
		ModContent.TileType<HelioStone>(),
		ModContent.TileType<AresStone>(),
		ModContent.TileType<HephStone>());
}

using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Snow;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.Content.Tiles.Natural.Stone.Mossy;

namespace Xenon.Common.Data;

internal class TileSets
{
	public static bool[] MountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<OuranoStone>(),
		ModContent.TileType<NyxStone>(),
		ModContent.TileType<HelioStone>(),
		ModContent.TileType<AresStone>(),
		ModContent.TileType<HephStone>()
	);

	public static bool[] MossyMountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<MossyOuranoStone>(),
		ModContent.TileType<MossyNyxStone>(),
		ModContent.TileType<MossyHelioStone>(),
		ModContent.TileType<MossyAresStone>(),
		ModContent.TileType<MossyHephStone>()
	);

	public static readonly HashSet<int> Stalac = new()
	{
		ModContent.TileType<RhyoliteStalactgmites>(),
		ModContent.TileType<FrozenLavaStalac>(),
		ModContent.TileType<GutstoneStalac>(),
		ModContent.TileType<OuranoStalac>(),
		ModContent.TileType<NyxStalac>(),
		ModContent.TileType<HephStalac>(),
		ModContent.TileType<AresStalac>(),
		ModContent.TileType<HelioStalac>()
	};
	public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

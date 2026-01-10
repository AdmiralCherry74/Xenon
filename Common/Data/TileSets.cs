using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Snow;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.Content.Tiles.Natural.Stone.Mossy;
using Xenon.ModSupport.Confection.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone.Mossy;

namespace Xenon.Common.Data;

internal class TileSets
{
	public static bool[] MountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<OuranoStone>(),
		ModContent.TileType<NyxStone>(),
		ModContent.TileType<HelioStone>(),
		ModContent.TileType<AresStone>(),
		ModContent.TileType<HephStone>(),
		ModContent.TileType<HestiaStone>()
	);
	public static bool[] Quicksand = TileID.Sets.Factory.CreateBoolSet(
	ModContent.TileType<Quicksand>(),
	ModContent.TileType<Ebonquicksand>(),
	ModContent.TileType<Crimquicksand>(),
	ModContent.TileType<Pearlquicksand>(),
	ModContent.TileType<Gutquicksand>(),
	ModContent.TileType<CreamQuicksand>()
	);
	public static bool[] EvilOre = TileID.Sets.Factory.CreateBoolSet(
    TileID.Demonite,
    TileID.Crimtane,
	ModContent.TileType<IngestaneOre>()
	);

    public static bool[] MossyMountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<MossyOuranoStone>(),
		ModContent.TileType<MossyNyxStone>(),
		ModContent.TileType<MossyHelioStone>(),
		ModContent.TileType<MossyAresStone>(),
		ModContent.TileType<MossyHephStone>(),
		ModContent.TileType<MossyHestiaStone>()
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

using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Bricks;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.ForestMushroom;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.Other;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.Common.Data;

internal class TileSets
{
	public static bool[] MountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<OuranoStone>(),
		ModContent.TileType<NyxStone>(),
		ModContent.TileType<HelioStone>(),
		ModContent.TileType<AresStone>(),
		ModContent.TileType<HephStone>(),
		ModContent.TileType<HestiaStone>(),
		ModContent.TileType<PolloStone>()
	);

    public static bool[] ForestMushroomBiome = TileID.Sets.Factory.CreateBoolSet(
        ModContent.TileType<MushroomGrass>()
    );

    public static bool[] Quicksand = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<Quicksand>(),
		ModContent.TileType<Ebonquicksand>(),
		ModContent.TileType<Crimquicksand>(),
		ModContent.TileType<Pearlquicksand>(),
		ModContent.TileType<Gutquicksand>(),
		ModContent.TileType<Creamquicksand>(),
		ModContent.TileType<Snotquicksand>()
	);

	public static bool[] MossyMountainStone = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<MossyOuranoStone>(),
		ModContent.TileType<MossyNyxStone>(),
		ModContent.TileType<MossyHelioStone>(),
		ModContent.TileType<MossyAresStone>(),
		ModContent.TileType<MossyHephStone>(),
		ModContent.TileType<MossyHestiaStone>(),
		ModContent.TileType<MossyPolloStone>()
	);

	public static bool[] EvilOre = TileID.Sets.Factory.CreateBoolSet(
		TileID.Demonite,
		TileID.Crimtane,
		ModContent.TileType<IngestaneOre>()
	);

	public static bool[] Catacombs = TileID.Sets.Factory.CreateBoolSet(
		ModContent.TileType<RedCatacombBrick>(),
		ModContent.TileType<CharcoalCatacombBrick>(),
		ModContent.TileType<LavenderCatacombBrick>()
	);

	public static bool[] DungeonConvertBlue = TileID.Sets.Factory.CreateBoolSet(
		//Just using this for conversions
		TileID.BlueDungeonBrick
	);

	public static bool[] CatacombConvertPeriwinkle = TileID.Sets.Factory.CreateBoolSet(
		//Just using this for conversions
		ModContent.TileType<LavenderCatacombBrick>()
	);

	public static bool[] DungeonConvertPink = TileID.Sets.Factory.CreateBoolSet(
        //Just using this for conversions
        TileID.PinkDungeonBrick
	);

	public static bool[] CatacombConvertRed = TileID.Sets.Factory.CreateBoolSet(
		//Just using this for conversions
		ModContent.TileType<RedCatacombBrick>()
	);

	public static bool[] DungeonConvertGreen = TileID.Sets.Factory.CreateBoolSet(
		//Just using this for conversions
		TileID.GreenDungeonBrick
	);

    public static bool[] CatacombConvertCharcoal = TileID.Sets.Factory.CreateBoolSet(
        //Just using this for conversions
        ModContent.TileType<CharcoalCatacombBrick>()
    );

    public static bool[] Purity = TileID.Sets.Factory.CreateBoolSet(
	//made for use with Confection compatibility. this will not be used in most other cases
		TileID.Dirt,
		TileID.Grass,
		TileID.Stone,
		TileID.SnowBlock,
		TileID.IceBlock,
        TileID.JungleGrass,
        TileID.Sand,
		TileID.Sandstone,
		TileID.HardenedSand,
		ModContent.TileType<Quicksand>(),
		ModContent.TileType<OuranoStone>()
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

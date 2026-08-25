using Avalon.Tiles.Contagion;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Tiles;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;
using Xenon.Content.Tiles.Natural.NaturalStone;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;
using Xenon.Content.Tiles.Natural.Other;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.Common.Data;

[ReinitializeDuringResizeArrays]
public class TileSets
{

	public static readonly bool[] OnlyPlaceGemStashesOnThese = TileID.Sets.Factory.CreateBoolSet(
		TileID.Stone, TileID.Sandstone
	);

	public static bool[] MountainStone = TileID.Sets.Factory.CreateBoolSet(
        ModContent.TileType<OuranoStone>(),
        ModContent.TileType<NyxStone>(),
        ModContent.TileType<HelioStone>(),
        ModContent.TileType<AresStone>(),
        ModContent.TileType<HephStone>()
    );

    public static bool[] Quicksand = TileID.Sets.Factory.CreateBoolSet(
        ModContent.TileType<Quicksand>(),
        ModContent.TileType<Ebonquicksand>(),
        ModContent.TileType<Crimquicksand>(),
        ModContent.TileType<Pearlquicksand>(),
        ModContent.TileType<Gutquicksand>(),
        ModContent.TileType<MarineQuicksand>()
    );

    public static bool[] MossyMountainStone = TileID.Sets.Factory.CreateBoolSet(
        ModContent.TileType<MossyOuranoStone>(),
        ModContent.TileType<MossyNyxStone>(),
        ModContent.TileType<MossyHelioStone>(),
        ModContent.TileType<MossyAresStone>(),
        ModContent.TileType<MossyHephStone>()
    );

    public static bool[] EvilOre = TileID.Sets.Factory.CreateBoolSet(
        TileID.Demonite,
        TileID.Crimtane,
        ModContent.TileType<IngestaneOre>()
    );
    public static bool[] DontPlaceTheGemStashesOnThese = TileID.Sets.Factory.CreateBoolSet(
            TileID.RollingCactus,
            TileID.BreakableIce,
            TileID.IceBlock,
            TileID.Sand,
            TileID.SnowBlock,
            TileID.Ebonstone,
            TileID.Crimstone,
            TileID.Dirt
    );
    public static readonly bool[] PlaceTheGemStashesOnThese = TileID.Sets.Factory.CreateBoolSet(
        TileID.Stone, TileID.Sandstone
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

    public static bool[] ExoticConvertGrass = TileID.Sets.Factory.CreateBoolSet(
        // Exotic Grasses
        TileID.JungleGrass,
        ModContent.TileType<AutumnGrass>()
    );

    public static bool[] ConvertMushroomGrass = TileID.Sets.Factory.CreateBoolSet(
        // Mushroom Grass hotswapping for the base.
        TileID.MushroomGrass,
        ModContent.TileType<MushroomGrassMulch>()
    );

    public static bool[] ExoticConvertGround = TileID.Sets.Factory.CreateBoolSet(
        //made for use with Confection compatibility. this will not be used in most other cases
        TileID.Mud,
        ModContent.TileType<Mulch>()
    );

    public static bool[] ExoticConvertTemple = TileID.Sets.Factory.CreateBoolSet(
        //made for use with Confection compatibility. this will not be used in most other cases
        TileID.LihzahrdBrick,
        ModContent.TileType<AvianPlating>()
    );

    public static bool[] ExoticConvertHive = TileID.Sets.Factory.CreateBoolSet(
        //made for use with Confection compatibility. this will not be used in most other cases
        TileID.Hive,
        ModContent.TileType<ColonyBlock>()
    );

    public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

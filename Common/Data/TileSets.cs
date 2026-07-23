using Avalon.Tiles.Contagion;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Tiles;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.NaturalStone;
using Xenon.Content.Tiles.Natural.Ores;
using Xenon.Content.Tiles.Natural.Other;
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
        ModContent.TileType<HephStone>()
    );

    public static bool[] MirageTileSet = TileID.Sets.Factory.CreateBoolSet(
        TileID.HardenedSand,
        TileID.CorruptHardenedSand,
        TileID.CrimsonHardenedSand,
        ModContent.TileType<HardenedGutsand>(),
        TileID.HallowHardenedSand,
        TileID.Sandstone,
        TileID.CorruptSandstone,
        TileID.CrimsonSandstone,
        ModContent.TileType<Gutsandstone>(),
        TileID.HallowSandstone
    );

    public static bool[] Quicksand = TileID.Sets.Factory.CreateBoolSet(
        ModContent.TileType<Quicksand>(),
        ModContent.TileType<Ebonquicksand>(),
        ModContent.TileType<Crimquicksand>(),
        ModContent.TileType<Pearlquicksand>(),
        ModContent.TileType<Gutquicksand>()
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
    public static bool[] Tier1Ore = TileID.Sets.Factory.CreateBoolSet(
        TileID.Copper,
        TileID.Tin
    );
    public static bool[] Tier2Ore = TileID.Sets.Factory.CreateBoolSet(
        TileID.Iron,
        TileID.Lead
    );
    public static bool[] Tier3Ore = TileID.Sets.Factory.CreateBoolSet(
        TileID.Silver,
        TileID.Tungsten
    );
    public static bool[] Tier4Ore = TileID.Sets.Factory.CreateBoolSet(
        TileID.Gold,
        TileID.Platinum
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

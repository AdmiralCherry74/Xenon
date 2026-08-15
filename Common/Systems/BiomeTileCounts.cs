using System;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;
using Xenon.Content.Tiles.Natural.OceanAndTheMarine;
using Xenon.Content.Tiles.Natural.Other;
using Xenon.Content.Tiles.Natural.Somnolent;

namespace Xenon.Common.Systems;

public class BiomeTileCounts : ModSystem
{
    public int CorrosionTiles { get; private set; }
    public int CorrosionDesertTiles { get; private set; }
    public int SomnolentTiles { get; private set; }
    public int FrozenLavaTiles { get; private set; }
    public int MountainTiles { get; set; }
    public int UndergroundOceanTiles { get; set; }
    public int ForestMushroomTiles { get; set; }
    public int CorrosionJungleTiles { get; set; }
    public int CorruptionJungleTiles { get; set; }
    public int CrimsonJungleTiles { get; set; }
    public int CatacombTiles { get; set; }
    public int AutumnTiles { get; set; }
    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Gutsand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Quicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Ebonquicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Crimquicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Pearlquicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Gutquicksand>()];
        Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<Ebonquicksand>()];
        Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<Crimquicksand>()];
        Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<Pearlquicksand>()];
        Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<PowderedSnow>()];
        Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<FrozenLava>()];
        Main.SceneMetrics.JungleTileCount += tileCounts[ModContent.TileType<CorrosionJungleGrass>()];
        Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<NyxStone>()];
        Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<AresStone>()];
        Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<HelioStone>()];
        Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<MossyNyxStone>()];
        Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<MossyAresStone>()];
        Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<MossyHelioStone>()];


        UndergroundOceanTiles = tileCounts[ModContent.TileType<MarineSand>()] +
                               tileCounts[ModContent.TileType<HardenedMarineSand>()] +
                               tileCounts[ModContent.TileType<MarineSandstone>()] +
                               tileCounts[ModContent.TileType<MarineQuicksand>()];

        CorrosionTiles = tileCounts[ModContent.TileType<Gutstone>()] +
                         tileCounts[ModContent.TileType<HardenedGutsand>()] +
                         tileCounts[ModContent.TileType<Gutsandstone>()] +
                         tileCounts[ModContent.TileType<CorrosionGrass>()] +
                         tileCounts[ModContent.TileType<CorrosionJungleGrass>()] +
                         tileCounts[ModContent.TileType<Gutquicksand>()] +
                         tileCounts[ModContent.TileType<Gutsand>()] +
                         tileCounts[ModContent.TileType<BrownIce>()] +
                         tileCounts[ModContent.TileType<HephStone>()] +
                         tileCounts[ModContent.TileType<MossyHephStone>()];

        CorrosionDesertTiles = tileCounts[ModContent.TileType<Gutsand>()] +
                               tileCounts[ModContent.TileType<HardenedGutsand>()] +
                               tileCounts[ModContent.TileType<Gutsandstone>()] +
                               tileCounts[ModContent.TileType<Gutquicksand>()];

        SomnolentTiles = tileCounts[ModContent.TileType<Snoozestone>()] +
                         tileCounts[ModContent.TileType<SleepingGrass>()] +
                         tileCounts[ModContent.TileType<IndigoIce>()];

        AutumnTiles = tileCounts[ModContent.TileType<AutumnGrass>()];

        FrozenLavaTiles = tileCounts[ModContent.TileType<FrozenLava>()];

        MountainTiles = tileCounts[ModContent.TileType<OuranoStone>()] +
                        tileCounts[ModContent.TileType<NyxStone>()] +
                        tileCounts[ModContent.TileType<AresStone>()] +
                        tileCounts[ModContent.TileType<HelioStone>()] +
                        tileCounts[ModContent.TileType<HephStone>()] +
                        tileCounts[ModContent.TileType<MossyOuranoStone>()] +
                        tileCounts[ModContent.TileType<MossyNyxStone>()] +
                        tileCounts[ModContent.TileType<MossyAresStone>()] +
                        tileCounts[ModContent.TileType<MossyHelioStone>()] +
                        tileCounts[ModContent.TileType<MossyHephStone>()];

        CatacombTiles = tileCounts[ModContent.TileType<RedCatacombBrick>()] +
                        tileCounts[ModContent.TileType<CharcoalCatacombBrick>()] +
                        tileCounts[ModContent.TileType<LavenderCatacombBrick>()];
    }
}

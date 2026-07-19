using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.Ores;
using Xenon.Content.Tiles.Natural.Somnolent;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Content.WorldGeneration.Helpers;

public static class ConversionHelper
{
    public static void ConvertToCorrosion(int i, int j, int size = 4)
    {
        for (var x = i - size; x <= i + size; x++)
        {
            for (var y = j - size; y <= j + size; y++)
            {
                if (!WorldGen.InWorld(x, y, 1) || Math.Abs(x - i) + Math.Abs(y - j) >= Math.Sqrt(size * size + size * size))
                    continue;

                if (Main.tile[x, y].TileType > TileLoader.TileCount || Main.tile[x, y].WallType > WallLoader.WallCount)
                    continue;

                // Walls
                //_ = ConvertWall<ContagionGrassWall>(x, y, type => WallID.Sets.Conversion.Grass[type]) ||
                //    ConvertWall<ChunkstoneWall>(x, y, type => WallID.Sets.Conversion.Stone[type]) ||
                //    ConvertWall<HardenedSnotsandWallUnsafe>(x, y, type => WallID.Sets.Conversion.HardenedSand[type]) ||
                //    ConvertWall<SnotsandstoneWallUnsafe>(x, y, type => WallID.Sets.Conversion.Sandstone[type]) ||
                //    ConvertWall<ContagionLumpWall>(x, y, type => WallID.Sets.Conversion.NewWall1[type]) ||
                //    ConvertWall<ContagionMouldWall>(x, y, type => WallID.Sets.Conversion.NewWall2[type]) ||
                //    ConvertWall<ContagionCystWallUnsafe>(x, y, type => WallID.Sets.Conversion.NewWall3[type]) ||
                //    ConvertWall<ContagionBoilWall>(x, y, type => WallID.Sets.Conversion.NewWall4[type]);

                // Tiles
                _ = ConvertTile<Gutstone>(x, y, type => Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]) ||
                    ConvertTile<CorrosionJungleGrass>(x, y, type => TileID.Sets.Conversion.JungleGrass[type]) ||
                    ConvertTile<CorrosionGrass>(x, y, type => TileID.Sets.Conversion.Grass[type]) ||
                    ConvertTile<BrownIce>(x, y, type => TileID.Sets.Conversion.Ice[type]) ||
                    ConvertTile<Gutsand>(x, y, type => TileID.Sets.Conversion.Sand[type]) ||
                    ConvertTile<HardenedGutsand>(x, y, type => TileID.Sets.Conversion.HardenedSand[type], false) ||
                    ConvertTile<Gutsandstone>(x, y, type => TileID.Sets.Conversion.Sandstone[type], false) ||
                    ConvertTile<CorrosionThornyBushes>(x, y, type => TileID.Sets.Conversion.Thorn[type], false) ||
                    ConvertTile<HephStone>(x, y, type => Common.Data.TileSets.MountainStone[type], false) ||
                    ConvertTile<MossyHephStone>(x, y, type => Common.Data.TileSets.MossyMountainStone[type], false) ||
                    ConvertTile<Gutquicksand>(x, y, type => Common.Data.TileSets.Quicksand[type], false) ||
                    ConvertTile<IngestaneOre>(x, y, type => Common.Data.TileSets.EvilOre[type], false);
            }
        }

    }
    public static void ConvertToSomnolent(int i, int j, int size = 4)
    {
        for (var x = i - size; x <= i + size; x++)
        {
            for (var y = j - size; y <= j + size; y++)
            {
                if (!WorldGen.InWorld(x, y, 1) || Math.Abs(x - i) + Math.Abs(y - j) >= Math.Sqrt(size * size + size * size))
                    continue;

                if (Main.tile[x, y].TileType > TileLoader.TileCount || Main.tile[x, y].WallType > WallLoader.WallCount)
                    continue;

                // Walls
                //_ = ConvertWall<ContagionGrassWall>(x, y, type => WallID.Sets.Conversion.Grass[type]) ||
                //    ConvertWall<ChunkstoneWall>(x, y, type => WallID.Sets.Conversion.Stone[type]) ||
                //    ConvertWall<HardenedSnotsandWallUnsafe>(x, y, type => WallID.Sets.Conversion.HardenedSand[type]) ||
                //    ConvertWall<SnotsandstoneWallUnsafe>(x, y, type => WallID.Sets.Conversion.Sandstone[type]) ||
                //    ConvertWall<ContagionLumpWall>(x, y, type => WallID.Sets.Conversion.NewWall1[type]) ||
                //    ConvertWall<ContagionMouldWall>(x, y, type => WallID.Sets.Conversion.NewWall2[type]) ||
                //    ConvertWall<ContagionCystWallUnsafe>(x, y, type => WallID.Sets.Conversion.NewWall3[type]) ||
                //    ConvertWall<ContagionBoilWall>(x, y, type => WallID.Sets.Conversion.NewWall4[type]);

                // Tiles
                _ = ConvertTile<Snoozestone>(x, y, type => Main.tileMoss[type] || TileID.Sets.Conversion.Stone[type]);
                    //ConvertTile<CorrosionJungleGrass>(x, y, type => TileID.Sets.Conversion.JungleGrass[type]) ||
                    //ConvertTile<CorrosionGrass>(x, y, type => TileID.Sets.Conversion.Grass[type]) ||
                    //ConvertTile<BrownIce>(x, y, type => TileID.Sets.Conversion.Ice[type]) ||
                    //ConvertTile<Gutsand>(x, y, type => TileID.Sets.Conversion.Sand[type]) ||
                    //ConvertTile<HardenedGutsand>(x, y, type => TileID.Sets.Conversion.HardenedSand[type], false) ||
                    //ConvertTile<Gutsandstone>(x, y, type => TileID.Sets.Conversion.Sandstone[type], false) ||
                    //ConvertTile<CorrosionThornyBushes>(x, y, type => TileID.Sets.Conversion.Thorn[type], false) ||
                    //ConvertTile<HephStone>(x, y, type => Common.Data.TileSets.MountainStone[type], false) ||
                    //ConvertTile<MossyHephStone>(x, y, type => Common.Data.TileSets.MossyMountainStone[type], false) ||
                    //ConvertTile<Gutquicksand>(x, y, type => Common.Data.TileSets.Quicksand[type], false) ||
                    //ConvertTile<IngestaneOre>(x, y, type => Common.Data.TileSets.EvilOre[type], false);
            }
        }

    }
    public static void ConvertToCatacomb(int i, int j, int size = 4)
    {
        for (var x = i - size; x <= i + size; x++)
        {
            for (var y = j - size; y <= j + size; y++)
            {
                if (!WorldGen.InWorld(x, y, 1) || Math.Abs(x - i) + Math.Abs(y - j) >= Math.Sqrt(size * size + size * size))
                    continue;

                if (Main.tile[x, y].TileType > TileLoader.TileCount || Main.tile[x, y].WallType > WallLoader.WallCount)
                    continue;

                // Walls
                _ = ConvertWall<RedCatacombWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallPink[type], false) ||
                        ConvertWall<RedCatacombTileWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallTilePink[type], false) ||
                        ConvertWall<RedCatacombSlabWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallSlabPink[type], false) ||
                    ConvertWall<CharcoalCatacombWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallGreen[type], false) ||
                        ConvertWall<CharcoalCatacombTileWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallTileGreen[type], false) ||
                        ConvertWall<CharcoalCatacombSlabWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallSlabGreen[type], false) ||
                    ConvertWall<LavenderCatacombWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallBlue[type], false) ||
                        ConvertWall<LavenderCatacombTileWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallTileBlue[type], false) ||
                        ConvertWall<LavenderCatacombSlabWallUnsafe>(x, y, type => Common.Data.WallSets.DungeonConvertWallSlabBlue[type], false);

                // Tiles
                _ = ConvertTile<LavenderCatacombBrick>(x, y, type => Common.Data.TileSets.DungeonConvertBlue[type], false) ||
                    ConvertTile<CharcoalCatacombBrick>(x, y, type => Common.Data.TileSets.DungeonConvertGreen[type], false) ||
                    ConvertTile<RedCatacombBrick>(x, y, type => Common.Data.TileSets.DungeonConvertPink[type], false);
            }
        }
    }

    public static void ConvertToDungeon(int i, int j, int size = 4)
    {
        for (var x = i - size; x <= i + size; x++)
        {
            for (var y = j - size; y <= j + size; y++)
            {
                if (!WorldGen.InWorld(x, y, 1) || Math.Abs(x - i) + Math.Abs(y - j) >= Math.Sqrt(size * size + size * size))
                    continue;

                if (Main.tile[x, y].TileType > TileLoader.TileCount || Main.tile[x, y].WallType > WallLoader.WallCount)
                    continue;

                // Walls
                _ = ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallRed[type], WallID.PinkDungeonUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallTileRed[type], WallID.PinkDungeonTileUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallSlabRed[type], WallID.PinkDungeonSlabUnsafe) ||
                    ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallCharcoal[type], WallID.GreenDungeonUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallTileCharcoal[type], WallID.GreenDungeonTileUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallSlabCharcoal[type], WallID.GreenDungeonSlabUnsafe) ||
                    ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallLavender[type], WallID.BlueDungeonUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallTileLavender[type], WallID.BlueDungeonTileUnsafe) ||
                        ConvertWall(x, y, type => Common.Data.WallSets.CatacombConvertWallSlabLavender[type], WallID.BlueDungeonSlabUnsafe);

                // Tiles
                _ = ConvertTile(x, y, type => Common.Data.TileSets.CatacombConvertRed[type], TileID.PinkDungeonBrick) ||
                    ConvertTile(x, y, type => Common.Data.TileSets.CatacombConvertCharcoal[type], TileID.GreenDungeonBrick) ||
                    ConvertTile(x, y, type => Common.Data.TileSets.CatacombConvertPeriwinkle[type], TileID.BlueDungeonBrick);
            }
        }
    }
    private static bool ConvertWall<TWall>(int x, int y, Func<int, bool> validTypePredicate, bool v) where TWall : ModWall
    {
        return ConvertWall(x, y, validTypePredicate, ModContent.WallType<TWall>());
    }

    private static bool ConvertWall(int x, int y, Func<int, bool> validTypePredicate, int wallType)
    {
        if (!validTypePredicate(Main.tile[x, y].WallType) || Main.tile[x, y].WallType == wallType)
            return false;

        Main.tile[x, y].WallType = (ushort)wallType;
        WorldGen.SquareWallFrame(x, y);
        NetMessage.SendTileSquare(-1, x, y);

        return true;
    }

    private static bool ConvertTile<TTile>(int x, int y, Func<int, bool> validTypePredicate, bool tryKillTreeAbove = true) where TTile : ModTile
    {
        return ConvertTile(x, y, validTypePredicate, ModContent.TileType<TTile>(), tryKillTreeAbove);
    }

    private static bool ConvertTile(int x, int y, Func<int, bool> validTypePredicate, int tileType, bool tryKillTreeAbove = true)
    {
        if (!validTypePredicate(Main.tile[x, y].TileType) || Main.tile[x, y].TileType == tileType)
            return false;

        if (tryKillTreeAbove)
            WorldGen.TryKillingTreesAboveIfTheyWouldBecomeInvalid(x, y, tileType);

        Main.tile[x, y].TileType = (ushort)tileType;
        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendData(MessageID.TileSquare, -1, -1, null, x, y, 1, 1, 0);
        }
        if (tileType == ModContent.TileType<CorrosionGrass>() && Main.tile[x, y - 1].TileType == TileID.Pumpkins)
        {
            WorldGen.KillTile(x, y - 1);
            if (!Main.tile[x, y - 1].HasTile && Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, x, y - 1);
            }
        }
        WorldGen.SquareTileFrame(x, y);
        NetMessage.SendTileSquare(-1, x, y);

        return true;
    }
}

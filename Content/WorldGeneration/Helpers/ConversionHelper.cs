using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;

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
                    ConvertTile<TanIce>(x, y, type => TileID.Sets.Conversion.Ice[type]) ||
                    ConvertTile<Gutsand>(x, y, type => TileID.Sets.Conversion.Sand[type]) ||
                    ConvertTile<HardenedGutsand>(x, y, type => TileID.Sets.Conversion.HardenedSand[type], false) ||
                    ConvertTile<Gutsandstone>(x, y, type => TileID.Sets.Conversion.Sandstone[type], false) ||
                    ConvertTile<CorrosionThornyBushes>(x, y, type => TileID.Sets.Conversion.Thorn[type], false);
            }
        }
    }

    private static bool ConvertWall<TWall>(int x, int y, Func<int, bool> validTypePredicate) where TWall : ModWall
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

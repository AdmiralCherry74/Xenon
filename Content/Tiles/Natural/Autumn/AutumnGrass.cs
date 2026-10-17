using System.Security.Policy;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Placeable.Blocks.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class AutumnGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;

        Main.tileMerge[Type][ModContent.TileType<Mulch>()] = true;

        TileID.Sets.Grass[Type] = true;
        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.ForcedDirtMerging[Type] = true;
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        TileID.Sets.Conversion.Dirt[Type] = true;

        TileID.Sets.SpreadOverground[Type] = true;

        DustType = ModContent.DustType<MulchDust>();
        AddMapEntry(new Color(175, 64, 42));
        RegisterItemDrop(ModContent.ItemType<MulchBlock>());
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (fail && !effectOnly)
        {
            if (Main.tile[i, j - 1].TileType == ModContent.TileType<AutumnFoliage>())
            {
                WorldGen.KillTile(i, j - 1);
            }
            if (Main.tile[i, j + 1].TileType == ModContent.TileType<AutumnVines>())
            {
                WorldGen.KillTile(i, j + 1);
            }
            noItem = true;
            Main.tile[i, j].TileType = (ushort)ModContent.TileType<Mulch>();
            WorldGen.SquareTileFrame(i, j);
        }
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tile = ((Tilemap)(Main.tile))[i, j];
        Tile up = ((Tilemap)(Main.tile))[i, j - 1];
        Tile up2 = ((Tilemap)(Main.tile))[i, j - 2];
        if (!((Tile)(up)).HasTile && !((Tile)(up2)).HasTile && (((Tile)(up)).LiquidAmount <= 0 || ((Tile)(up2)).LiquidAmount <= 0) && !((Tile)(tile)).LeftSlope && !((Tile)(tile)).RightSlope && !((Tile)(tile)).IsHalfBlock)
        {
            if (Utils.NextBool(WorldGen.genRand, 10))
            {
                ((Tile)(up)).TileType = (ushort)ModContent.TileType<AutumnFoliage>();
                ((Tile)(up)).HasTile = true;
                ((Tile)(up)).TileFrameY = 0;

                if (Utils.NextBool(WorldGen.genRand))
                {
                    ((Tile)(up)).TileFrameX = (short)(WorldGen.genRand.Next(6) * 18);
                    WorldGen.SquareTileFrame(i, j - 1, true);
                    if (Main.dedServ)
                    {
                        NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
                    }
                } else {
                    ((Tile)(up)).TileFrameX = (short)((WorldGen.genRand.Next(13) + 10) * 18);
                    
                }
                WorldGen.SquareTileFrame(i, j - 1, true);
                if (Main.dedServ)
                {
                    NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
                }
            } else if (j > Main.worldSurface && Utils.NextBool(WorldGen.genRand, 20))
            {
                ((Tile)(up)).TileType = (ushort)ModContent.TileType<AutumnFoliage>();
                ((Tile)(up)).HasTile = true;
                ((Tile)(up)).TileFrameY = 0;

                if (Utils.NextBool(WorldGen.genRand))
                    ((Tile)(up)).TileFrameX = (short)(6 * 18);
                else
                    ((Tile)(up)).TileFrameX = (short)(7 * 18);

                WorldGen.SquareTileFrame(i, j - 1, true);
                if (Main.dedServ)
                {
                    NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
                }
            } else if (j > Main.worldSurface && Utils.NextBool(WorldGen.genRand, 40))
            {
                ((Tile)(up)).TileType = (ushort)ModContent.TileType<AutumnFoliage>();
                ((Tile)(up)).HasTile = true;
                ((Tile)(up)).TileFrameY = 0;

                ((Tile)(up)).TileFrameX = (short)(9 * 18);

                WorldGen.SquareTileFrame(i, j - 1, true);
                if (Main.dedServ)
                {
                    NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
                }
            }
        }
    }
}

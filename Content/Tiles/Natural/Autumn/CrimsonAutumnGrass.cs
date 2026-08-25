using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Autumn;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class CrimsonAutumnGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(183, 69, 68));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<Mulch>()] = true;

        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.CrimsonBiomeSight[Type] = true;
        //TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = false;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        //TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
        TileID.Sets.SpreadOverground[Type] = true;
        TileID.Sets.SpreadUnderground[Type] = true;
        //TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        RegisterItemDrop(ModContent.ItemType<MulchBlock>());
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (fail && !effectOnly)
        {
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
        if (Utils.NextBool(WorldGen.genRand, 10) && !((Tile)(up)).HasTile && !((Tile)(up2)).HasTile && (((Tile)(up)).LiquidAmount <= 0 || ((Tile)(up2)).LiquidAmount <= 0) && !((Tile)(tile)).LeftSlope && !((Tile)(tile)).RightSlope && !((Tile)(tile)).IsHalfBlock)
        {
            ((Tile)(up)).TileType = TileID.CrimsonPlants;
            ((Tile)(up)).HasTile = true;
            ((Tile)(up)).TileFrameY = 0;
            ((Tile)(up)).TileFrameX = (short)(WorldGen.genRand.Next(20) * 18);
            WorldGen.SquareTileFrame(i, j - 1, true);
            if (Main.dedServ)
            {
                NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
            }
        }
    }
}

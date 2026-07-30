using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.Other;

public class FleshyGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(176, 204, 40));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Conversion.Grass[Type] = true;
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        TileID.Sets.SpreadOverground[Type] = true;
        TileID.Sets.SpreadUnderground[Type] = true;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;

        //TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = false;
        //TileID.Sets.CanBeDugByShovel[Type] = true;
        //TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
        //TileID.Sets.SpreadOverground[Type] = true;
        //TileID.Sets.SpreadUnderground[Type] = true;
        TileID.Sets.Grass[Type] = true;
        //TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        RegisterItemDrop(ItemID.DirtBlock);
    }
}

//    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
//    {
//        if (fail && !effectOnly)
//        {
//            if (Main.tile[i, j - 1].TileType == ModContent.TileType<CorrosionShortGrass>())
//            {
//                WorldGen.KillTile(i, j - 1);
//            }
//            if (Main.tile[i, j + 1].TileType == ModContent.TileType<CorrosionVines>())
//            {
//                WorldGen.KillTile(i, j + 1);
//            }
//            noItem = true;
//            Main.tile[i, j].TileType = TileID.Dirt;
//            WorldGen.SquareTileFrame(i, j);
//        }
//    }
//}

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
}

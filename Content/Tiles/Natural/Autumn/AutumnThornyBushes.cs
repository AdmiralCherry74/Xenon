using Avalon.Prefixes;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.Organic;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class AutumnThornyBushes : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileMerge[Type][ModContent.TileType<AutumnThornyBushes>()] = true;
        Main.tileMerge[Type][TileID.JungleThorns] = true;

        Main.tileNoFail[Type] = true;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        TileID.Sets.Conversion.Thorn[Type] = true;
        TileID.Sets.TileCutIgnore.IgnoreDontHurtNature[Type] = true;
        TileID.Sets.GetsDestroyedForMeteors[Type] = true;
        TileID.Sets.TouchDamageDestroyTile[Type] = true;
        TileID.Sets.TouchDamageImmediate[Type] = 17;
        TileID.Sets.SpreadOverground[Type] = true;
        //TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        //TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
        //TileObjectData.newTile.CoordinateWidth = 16;
        //TileObjectData.newTile.CoordinatePadding = 2;
        //TileObjectData.newTile.StyleHorizontal = false;
        //TileObjectData.newTile.LavaDeath = false;
        //TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        AddMapEntry(new Color(114, 74, 76));
        DustType = ModContent.DustType<MulchDust>();
    
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (Main.rand.NextBool(30))
        {
            Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<SturdyThorn>()); //Change to proper item later
        }
    }
}
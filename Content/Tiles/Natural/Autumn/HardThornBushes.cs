using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.Organic;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class HardThornBushes : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileNoFail[Type] = true;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        TileID.Sets.TileCutIgnore.IgnoreDontHurtNature[Type] = true;
        TileID.Sets.GetsDestroyedForMeteors[Type] = true;
        TileID.Sets.TouchDamageDestroyTile[Type] = true;
        TileID.Sets.TouchDamageImmediate[Type] = 12;
        TileID.Sets.SpreadOverground[Type] = true;
        //TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        //TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
        //TileObjectData.newTile.CoordinateWidth = 16;
        //TileObjectData.newTile.CoordinatePadding = 2;
        //TileObjectData.newTile.StyleHorizontal = false;
        //TileObjectData.newTile.LavaDeath = false;
        //TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        AddMapEntry(new Color(140, 53, 74));
        DustType = ModContent.DustType<MulchDust>();

        RegisterItemDrop(ItemID.Pearlwood);
    }
}
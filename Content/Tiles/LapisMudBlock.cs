using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Content.Tiles;

public class LapisMudBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        Main.tileStone[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<Quickmud>()] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        TileID.Sets.Ore[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Items.Materials.Lapis>(), 1);
        AddMapEntry(new Color(92, 68, 73));
        HitSound = SoundID.Dig;
        DustType = DustID.DungeonBlue;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
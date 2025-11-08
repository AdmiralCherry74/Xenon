using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Items.Placeable.Tile.Natural.OresAndGems;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;

namespace Xenon.Content.Tiles.Natural.OresandGems;

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
        RegisterItemDrop(ModContent.ItemType<Lapis>());
        AddMapEntry(new Color(92, 68, 73));
        HitSound = SoundID.Dig;
        DustType = DustID.DungeonBlue;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
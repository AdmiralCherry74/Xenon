using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Items.Placeable.Tile.Natural.OresAndGems;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Tiles.Natural.Ores;

public class LapisSandstone : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        Main.tileStone[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<Quicksand>()] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        TileID.Sets.Ore[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Lapis>());
        AddMapEntry(new Color(50, 28, 110));
        HitSound = SoundID.Dig;
        DustType = ModContent.DustType<LapisGemDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
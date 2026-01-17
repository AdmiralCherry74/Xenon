using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

namespace Xenon.Content.Tiles.Natural.LivingWood;

public class DissolvingBilewoodBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.LivingWood] = true;
        Main.tileMerge[Type][TileID.LeafBlock] = true;
        Main.tileMerge[Type][TileID.LivingMahogany] = true;
        Main.tileMerge[Type][TileID.LivingMahoganyLeaves] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Bilewood>());
        AddMapEntry(new Color(125, 117, 143));
        HitSound = SoundID.Dig;
        DustType = ModContent.DustType<Dusts.BilewoodDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
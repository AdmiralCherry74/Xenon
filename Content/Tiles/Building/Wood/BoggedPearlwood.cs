using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Tiles.Building.Wood;

public class BoggedPearlwood : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileMerge[Type][TileID.Ebonstone] = true;
        Main.tileMerge[TileID.Ebonstone][Type] = true;
        Main.tileMerge[Type][TileID.Crimstone] = true;
        Main.tileMerge[TileID.Crimstone][Type] = true;
        Main.tileMerge[Type][TileID.Pearlstone] = true;
        Main.tileMerge[TileID.Pearlstone][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<Gutstone>()] = true;
        Main.tileMerge[ModContent.TileType<Gutstone>()][Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        RegisterItemDrop(ItemID.Pearlwood);
        AddMapEntry(new Color(200, 200, 200));
        HitSound = SoundID.Dig;
        DustType = DustID.Pearlwood;
        MineResist = 2f;
        MinPick = 110;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
    public override bool CanExplode(int i, int j)
    {
        if (Main.hardMode)
        {
            return true;
        }
        return false;
    }
}
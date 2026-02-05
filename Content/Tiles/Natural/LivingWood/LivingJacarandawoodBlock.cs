using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

namespace Xenon.Content.Tiles.Natural.LivingWood;

public class LivingJacarandawoodBlock : ModTile
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
        RegisterItemDrop(ModContent.ItemType<JacarandaWood>());
        AddMapEntry(new Color(61, 45, 33));
        MinPick = 45;
        MineResist = 1.5f;
        HitSound = SoundID.Dig;
        DustType = DustID.BorealWood;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}
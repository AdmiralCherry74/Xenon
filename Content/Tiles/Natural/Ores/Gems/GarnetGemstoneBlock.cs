using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Tiles.Natural.Ores.Gems;

public class GarnetGemstoneBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 900;
        TileID.Sets.Ore[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Garnet>());
        AddMapEntry(new Color(206, 1, 135), this.GetLocalization("MapEntry"));
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<GarnetGemDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
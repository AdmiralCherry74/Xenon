using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.OresBarsGems;

namespace Xenon.Content.Tiles.Natural.Ores;

public class GarnetMud : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Coralstone] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        TileID.Sets.Ore[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Garnet>());
        AddMapEntry(new Color(206, 1, 135));
        HitSound = SoundID.Dig;
        DustType = ModContent.DustType<GarnetGemDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
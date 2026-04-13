using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Tiles.Natural.Ores;

public class JadeGemstoneBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        TileID.Sets.IceSkateSlippery[Type] = true;
        TileID.Sets.Ore[Type] = true;
        AddMapEntry(new Color(69, 69, 69)); //Nice
        RegisterItemDrop(ModContent.ItemType<Jade>());
        HitSound = SoundID.Item50;
        DustType = ModContent.DustType<JadeGemDust>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles;

public class WhiteSlimeBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = true;
        AddMapEntry(new Color(200, 200, 200));
        HitSound = SoundID.Dig;
        DustType = ModContent.DustType<WhiteSlimeDust>();
        MineResist = 0.25f;
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
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles;

public class TintedGlass : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = true;
        AddMapEntry(new Color(5, 5, 5));
        HitSound = SoundID.Shatter;
        DustType = DustID.Asphalt;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
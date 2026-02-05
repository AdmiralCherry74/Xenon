using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Bricks;

public class RedCatacombBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(100, 0, 0));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.RedMoss;
        HitSound = SoundID.Tink;
        MinPick = 75;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}

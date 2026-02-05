using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Bricks;

public class CharcoalCatacombBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(5, 30, 50));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Lead;
        HitSound = SoundID.Tink;
        MinPick = 75;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Building.Bricks;

public class LavenderCatacombBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(105, 130, 170));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Silk;
        HitSound = SoundID.Tink;
        MinPick = 75;
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
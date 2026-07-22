using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Building.Bricks;

public class IndiumBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(94, 75, 155));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<IndiumDust>();
        HitSound = SoundID.Tink;
    }
}

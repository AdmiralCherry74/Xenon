using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Building.Bricks;

public class CinnabarBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(92, 29, 33));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<CinnabarDust>();
        HitSound = SoundID.Tink;
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Building.Bricks;

public class AluminumBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(132, 134, 146));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<AluminumDust>();
        HitSound = SoundID.Tink;
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Building.Bricks;

public class FluoriteBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(206, 106, 150));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<FluoriteDust>();
        HitSound = SoundID.Tink;
    }
}

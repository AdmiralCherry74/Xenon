using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Walls;

public class SmoothRhyoliteWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(50, 30, 27));
        DustType = ModContent.DustType<RhyoliteDust>();
    }
}

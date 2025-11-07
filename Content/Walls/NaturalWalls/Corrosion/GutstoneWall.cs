using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Corrosion;

public class GutstoneWall : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(55, 43, 0));
        DustType = ModContent.DustType<CorrosionDust>();
    }
}

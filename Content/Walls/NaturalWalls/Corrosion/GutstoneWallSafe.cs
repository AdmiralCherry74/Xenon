using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Corrosion;

public class GutstoneWallSafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(55, 43, 0));
        DustType = ModContent.DustType<CorrosionDust>();
    }
}

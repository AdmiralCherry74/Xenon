using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.Stone;

public class JadeGemstoneWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        Main.wallBlend[Type] = WallID.Stone;
        AddMapEntry(new Color(52, 52, 52));
        DustType = DustID.Stone;
    }
}

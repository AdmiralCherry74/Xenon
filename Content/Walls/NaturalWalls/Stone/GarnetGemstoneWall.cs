using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Stone;

public class GarnetGemstoneWall: ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallBlend[Type] = WallID.Stone;
        AddMapEntry(new Color(52, 52, 52));
        DustType = DustID.Stone;
    }
}

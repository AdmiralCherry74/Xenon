using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Bricks;

public class FluoriteBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(110, 53, 78));
        DustType = ModContent.DustType<FluoriteDust>();
    }
}

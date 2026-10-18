using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Bricks;

public class CinnabarBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(116, 33, 35));
        DustType = ModContent.DustType<CinnabarDust>();
    }
}

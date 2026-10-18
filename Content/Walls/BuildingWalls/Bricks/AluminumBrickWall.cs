using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Bricks;

public class AluminumBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(95, 97, 106));
        DustType = ModContent.DustType<AluminumDust>();
    }
}

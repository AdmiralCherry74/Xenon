using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Bricks;

public class IndiumBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(47, 36, 81));
        DustType = ModContent.DustType<IndiumDust>();
    }
}

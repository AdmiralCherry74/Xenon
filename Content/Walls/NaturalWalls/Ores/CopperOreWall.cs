using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class CopperOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(38, 2, 5));
        DustType = DustID.Copper;
    }
}

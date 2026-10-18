using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class SilverOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(77, 89, 91));
        DustType = DustID.Silver;
    }
}

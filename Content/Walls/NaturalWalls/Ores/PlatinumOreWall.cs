using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class PlatinumOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(42, 42, 69));
        DustType = DustID.Platinum;
    }
}

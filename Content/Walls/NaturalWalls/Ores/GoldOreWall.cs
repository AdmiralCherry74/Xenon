using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class GoldOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(152, 140, 39));
        DustType = DustID.Gold;
    }
}

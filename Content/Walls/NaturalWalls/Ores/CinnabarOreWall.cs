using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class CinnabarOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(105, 0, 16));
        DustType = ModContent.DustType<CinnabarDust>();
    }
}

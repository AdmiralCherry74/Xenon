using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class AluminumOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(101, 109, 107));
        DustType = ModContent.DustType<AluminumDust>();
    }
}

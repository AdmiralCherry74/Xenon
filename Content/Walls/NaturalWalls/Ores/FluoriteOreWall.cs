using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class FluoriteOreWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(65, 0, 31));
        DustType = ModContent.DustType<FluoriteDust>();
    }
}

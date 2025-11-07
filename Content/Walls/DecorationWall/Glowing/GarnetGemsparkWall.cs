using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles;

namespace Xenon.Content.Walls.DecorationWall.Glowing;

public class GarnetGemsparkWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        AddMapEntry(new Color(255, 50, 141));
        DustType = DustID.GemDiamond;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 100f / 105;
        g = 41.2f / 255;
        b = 70.6f / 105;
    }
}
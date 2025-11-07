using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles;

namespace Xenon.Content.Walls.DecorationWall.Glowing;

public class LapisGemsparkWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        AddMapEntry(new Color(129, 111, 211));
        DustType = DustID.GemDiamond;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 32.7f / 75;
        g = 2f / 75;
        b = 59.9f / 75;
    }
}
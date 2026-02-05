using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.DecorationWall.Glowing;

public class OnyxGemsparkWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        AddMapEntry(new Color(108, 108, 208));
        DustType = DustID.GemDiamond;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.3f;
        g = 0.3f;
        b = 0.3f;
    }
}
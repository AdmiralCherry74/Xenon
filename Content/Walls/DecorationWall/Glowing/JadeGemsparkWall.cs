using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.DecorationWall.Glowing;

public class JadeGemsparkWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        AddMapEntry(new Color(108, 108, 208));
        DustType = ModContent.DustType<JadeGemDust>();
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.2f;
        g = 0.3f;
        b = 0.1f;
    }
}
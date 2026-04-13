using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.DecorationWall.SeeThrough;

public class OliveStainedGlassWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.Transparent[Type] = true;
        AddMapEntry(new Color(108, 108, 108));
        DustType = DustID.GreenMoss;
        HitSound = SoundID.Shatter;
    }
}

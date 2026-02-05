using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.DecorationWall.SeeThrough;

public class PinkStainedGlassWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.Transparent[Type] = true;
        AddMapEntry(new Color(136, 75, 44));
        DustType = DustID.Ice_Red;
        HitSound = SoundID.Shatter;
    }
}

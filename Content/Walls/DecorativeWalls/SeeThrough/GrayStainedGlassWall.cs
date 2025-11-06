using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.DecorativeWalls.SeeThrough;

public class GrayStainedGlassWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.Transparent[Type] = true;
        AddMapEntry(new Color(108, 108, 108));
        DustType = DustID.Ash;
        HitSound = SoundID.Shatter;
    }
}

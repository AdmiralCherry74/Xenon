using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.DecorativeWalls.SeeThrough;

public class TintedGlassWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(5, 5, 5));
        HitSound = SoundID.Shatter;
        DustType = DustID.Asphalt;
    }
}

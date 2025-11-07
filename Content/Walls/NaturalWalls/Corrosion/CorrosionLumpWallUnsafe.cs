using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Corrosion;

public class CorrosionLumpWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        WallID.Sets.Conversion.NewWall1[Type] = true;
        AddMapEntry(new Color(61, 71, 51));
        DustType = ModContent.DustType<Dusts.CorrosionDust>();
    }
}

using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWall.CorrodedWall;

public class CorrosionCystWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        WallID.Sets.Conversion.NewWall3[Type] = true;
        AddMapEntry(new Color(56, 66, 59));
        DustType = ModContent.DustType<Dusts.CorrosionDust>();
    }
}

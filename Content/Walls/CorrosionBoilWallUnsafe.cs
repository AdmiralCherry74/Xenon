using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls;

public class CorrosionBoilWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        WallID.Sets.Conversion.NewWall4[Type] = true;
        AddMapEntry(new Color(63, 66, 56));
        DustType = ModContent.DustType<Dusts.CorrosionDust>();
    }
}

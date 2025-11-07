using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Corrosion;

public class CorrosionMoldWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        WallID.Sets.Conversion.NewWall2[Type] = true;
        AddMapEntry(new Color(71, 84, 54));
        DustType = ModContent.DustType<Dusts.CorrosionDust>();
    }
}

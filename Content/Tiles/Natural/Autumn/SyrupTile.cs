using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class SyrupTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;

		DustType = ModContent.DustType<SyrupDust>();
		AddMapEntry(new Color(192, 46, 24));
	}
    public override bool HasWalkDust() => Main.rand.NextBool(3);
    public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
    {
        dustType = DustType;
    }
}
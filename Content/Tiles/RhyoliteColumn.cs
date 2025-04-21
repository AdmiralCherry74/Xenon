using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles;

public class RhyoliteColumn : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(41, 25, 24));
        TileID.Sets.IsBeam[Type] = true;
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<RhyoliteDust>();
		HitSound = SoundID.Tink;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        height = 18;
    }
}

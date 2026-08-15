using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Building.Bricks;

public class DirtBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(151, 107, 75));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Dirt;
		HitSound = SoundID.Dig;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}
}

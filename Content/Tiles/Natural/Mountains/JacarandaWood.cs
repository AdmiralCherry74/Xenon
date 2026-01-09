using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.Mountains;

public class JacarandaWood : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(82, 71, 61));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.BorealWood;
		HitSound = SoundID.Tink;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}
}

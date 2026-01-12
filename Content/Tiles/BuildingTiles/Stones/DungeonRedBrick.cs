using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.BuildingTiles.Stones;

public class DungeonRedBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(100, 0, 0));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<CorrosionDust>();
		HitSound = SoundID.Tink;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}
}

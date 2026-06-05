using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Building.BuildingStone;

public class SmoothStone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(103, 103, 103));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Stone;
		HitSound = SoundID.Tink;
	}
}

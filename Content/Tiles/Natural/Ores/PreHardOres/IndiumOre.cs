using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Ores.PreHardOres;

public class IndiumOre : ModTile
{
    //Indium is a tier three phm ore
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1025;
        Main.tileOreFinderPriority[Type] = 255;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        AddMapEntry(new Color(31, 35, 84), this.GetLocalization("MapEntry"));
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<IndiumDust>();
		TileID.Sets.Ore[Type] = true;
	}

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
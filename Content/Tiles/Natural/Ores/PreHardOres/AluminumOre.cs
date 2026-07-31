using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Ores.PreHardOres;

public class AluminumOre : ModTile
{
    //Alluminum is a tier one phm ore
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        #region Ore Merging
        Main.tileMerge[Type][TileID.Copper] = true;
        Main.tileMerge[TileID.Copper][Type] = true;
        Main.tileMerge[Type][TileID.Tin] = true;
        Main.tileMerge[TileID.Tin][Type] = true;
        Main.tileMerge[Type][TileID.Iron] = true;
        Main.tileMerge[TileID.Iron][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<CinnabarOre>()] = true;
        Main.tileMerge[ModContent.TileType<CinnabarOre>()][Type] = true;
        Main.tileMerge[Type][TileID.Lead] = true;
        Main.tileMerge[TileID.Lead][Type] = true;
        Main.tileMerge[Type][TileID.Silver] = true;
        Main.tileMerge[TileID.Silver][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<IndiumOre>()] = true;
        Main.tileMerge[ModContent.TileType<IndiumOre>()][Type] = true;
        Main.tileMerge[Type][TileID.Tungsten] = true;
        Main.tileMerge[TileID.Tungsten][Type] = true;
        Main.tileMerge[Type][TileID.Gold] = true;
        Main.tileMerge[TileID.Gold][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<FluoriteOre>()] = true;
        Main.tileMerge[ModContent.TileType<FluoriteOre>()][Type] = true;
        Main.tileMerge[Type][TileID.Platinum] = true;
        Main.tileMerge[TileID.Platinum][Type] = true;
        #endregion
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1100;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 215;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        AddMapEntry(new Color(146, 157, 155), this.GetLocalization("MapEntry"));
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<AluminumDust>();
		TileID.Sets.Ore[Type] = true;
	}

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
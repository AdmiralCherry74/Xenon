using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Tiles.Natural.Stone.Mossy;

public class MossyAresStone : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[Type][TileID.Ebonstone] = true;
        Main.tileMerge[Type][TileID.CorruptGrass] = true;
        Main.tileMerge[Type][TileID.Crimstone] = true;
        Main.tileMerge[Type][TileID.CrimsonGrass] = true;
        Main.tileMerge[Type][TileID.Pearlstone] = true;
        Main.tileMerge[Type][TileID.HallowedGrass] = true;
        Main.tileMerge[Type][ModContent.TileType<CorrosionGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Gutstone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<AresStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<OuranoStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyOuranoStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<NyxStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyNyxStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<HelioStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyHelioStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<HephStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyHephStone>()] = true;
        AddMapEntry(new Color(136, 50, 49));
        Main.tileBlockLight[Type] = true;
        HitSound = SoundID.Tink;
        DustType = DustID.Stone;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}
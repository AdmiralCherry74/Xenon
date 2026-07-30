using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;

namespace Xenon.ModSupport.Avalon.Content.Tiles;

public class PolloStone : ModTile
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
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
		Main.tileMerge[Type][ModContent.TileType<MossyAresStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<OuranoStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<MossyOuranoStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<NyxStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<MossyNyxStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<HelioStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<MossyHelioStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<HephStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<MossyHephStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<AresStone>()] = true;
		Main.tileMerge[Type][ModContent.TileType<MossyAresStone>()] = true;
		Common.Data.TileSets.MountainStone[Type] = true;
		AddMapEntry(new Color(140, 88, 76));
		Main.tileBlockLight[Type] = true;
		HitSound = SoundID.Tink;
		DustType = DustID.Stone;
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}

	public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		if (!fail && !effectOnly)
		{
			if (Main.tile[i, j - 1].TileType == ModContent.TileType<PolloStalac>())
			{
				WorldGen.KillTile(i, j - 1);
				if (Main.tile[i, j - 2].TileType == ModContent.TileType<PolloStalac>())
				{
					WorldGen.KillTile(i, j - 2);
				}
			}
			if (Main.tile[i, j + 1].TileType == ModContent.TileType<PolloStalac>())
			{
				WorldGen.KillTile(i, j + 1);
				if (Main.tile[i, j + 2].TileType == ModContent.TileType<PolloStalac>())
				{
					WorldGen.KillTile(i, j + 2);
				}
			}
		}
	}
}
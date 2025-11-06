using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.NaturalTile.Stones;

public class Rhyolite : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(134, 85, 77));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<RhyoliteDust>();
		HitSound = SoundID.Tink;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}

	public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		if (!fail && !effectOnly)
		{
			if (Main.tile[i, j - 1].TileType == ModContent.TileType<RhyoliteStalactgmites>())
			{
				WorldGen.KillTile(i, j - 1);
				if (Main.tile[i, j - 2].TileType == ModContent.TileType<RhyoliteStalactgmites>())
				{
					WorldGen.KillTile(i, j - 2);
				}
			}
			if (Main.tile[i, j + 1].TileType == ModContent.TileType<RhyoliteStalactgmites>())
			{
				WorldGen.KillTile(i, j + 1);
				if (Main.tile[i, j + 2].TileType == ModContent.TileType<RhyoliteStalactgmites>())
				{
					WorldGen.KillTile(i, j + 2);
				}
			}
		}
	}
}

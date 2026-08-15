using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Placeable.Blocks.Natural.Autumn;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class AutumnGrass : ModTile
{
	public override void SetStaticDefaults()
	{
		//tileMerge[Type, Mod.Find<ModTile>("Mulch").Type] = true;
		//TheAutumn.tileMerge[Type, Mod.Find<ModTile>("Thornite").Type] = true;
		//tileMerge[Type, TileId.Stone] = true;
		//tileMerge[Type, TileId.Ash] = true;

		Main.tileSolid[Type] = true;
		Main.tileBlendAll[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBrick[Type] = true;
		Main.tileBlockLight[Type] = true;

		TileID.Sets.Grass[Type] = true;
		TileID.Sets.ChecksForMerge[Type] = true;
		TileID.Sets.ForcedDirtMerging[Type] = true;
		TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
		TileID.Sets.Conversion.Grass[Type] = true;

        DustType = ModContent.DustType<MulchDust>();
        AddMapEntry(new Color(235, 207, 150));
		RegisterItemDrop(ModContent.ItemType<MulchBlock>());
	}

	public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		if (fail && !effectOnly)
		{
			Main.tile[i, j].TileType = (ushort)ModContent.TileType<Mulch>();
		}
	}
}
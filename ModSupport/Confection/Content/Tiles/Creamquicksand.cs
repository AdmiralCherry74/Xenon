using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Other;
using Xenon.ModSupport.Confection.Content.Items;

namespace Xenon.ModSupport.Confection.Content.Tiles;
public class Creamquicksand : ModTile
{
	public override void SetStaticDefaults()
	{
		AddMapEntry(new Color(211, 151, 68));
		Main.tileSolid[Type] = false;
		Main.tileBrick[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileMerge[TileID.Sandstone][Type] = true;
		Main.tileMerge[Type][TileID.Sandstone] = true;
		Main.tileMerge[TileID.HardenedSand][Type] = true;
		Main.tileMerge[Type][TileID.HardenedSand] = true;
        Main.tileMerge[Type][ModContent.TileType<Quicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Ebonquicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Crimquicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Pearlquicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Gutquicksand>()] = true;
        MineResist = 0.5f;
		DustType = DustID.SandstormInABottle;

		TileID.Sets.CanPlaceNextToNonSolidTile[Type] = true;
		TileID.Sets.CanBeDugByShovel[Type] = true;
		TileID.Sets.Suffocate[Type] = true;

		TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
		TileID.Sets.ChecksForMerge[Type] = true;

		RegisterItemDrop(ModContent.ItemType<CreamQuicksandBlock>());
	}
	public override bool HasWalkDust() => Main.rand.NextBool(3);

	public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
	{
		dustType = DustType;
	}
	public override bool IsTileDangerous(int i, int j, Player player)
	{
		return true;
	}
}
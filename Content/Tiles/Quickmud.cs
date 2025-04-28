using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile;

namespace Xenon.Content.Tiles;
public class Quickmud : ModTile
{
	public override void SetStaticDefaults()
	{
		AddMapEntry(new Color(112, 84, 77));
		Main.tileSolid[Type] = false;
		Main.tileBrick[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileMerge[TileID.HallowSandstone][Type] = true;
		Main.tileMerge[Type][TileID.HallowSandstone] = true;
		Main.tileMerge[TileID.HallowHardenedSand][Type] = true;
		Main.tileMerge[Type][TileID.HallowHardenedSand] = true;
		MineResist = 0.5f;
		DustType = DustID.Pearlsand;

		TileID.Sets.CanPlaceNextToNonSolidTile[Type] = true;
		TileID.Sets.CanBeDugByShovel[Type] = true;
		TileID.Sets.Suffocate[Type] = true;

		TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
		TileID.Sets.ChecksForMerge[Type] = true;

		RegisterItemDrop(ModContent.ItemType<QuickmudBlock>());
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
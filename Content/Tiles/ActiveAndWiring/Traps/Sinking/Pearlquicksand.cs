using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Traps.Sinking;
using Xenon.ModSupport.Confection.Content.Tiles.ActiveAndWiring.Traps.Sinking;

namespace Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
public class Pearlquicksand : ModTile
{
	public override void SetStaticDefaults()
	{
		AddMapEntry(new Color(239, 219, 216));
		Main.tileSolid[Type] = false;
		Main.tileBrick[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileMerge[TileID.HallowSandstone][Type] = true;
		Main.tileMerge[Type][TileID.HallowSandstone] = true;
		Main.tileMerge[TileID.HallowHardenedSand][Type] = true;
		Main.tileMerge[Type][TileID.HallowHardenedSand] = true;
        Main.tileMerge[Type][ModContent.TileType<Quicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Ebonquicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Crimquicksand>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Gutquicksand>()] = true;
        MineResist = 0.5f;
		DustType = DustID.Pearlsand;

		TileID.Sets.CanPlaceNextToNonSolidTile[Type] = true;
		TileID.Sets.CanBeDugByShovel[Type] = true;
		TileID.Sets.Suffocate[Type] = true;

		TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
		TileID.Sets.ChecksForMerge[Type] = true;

		RegisterItemDrop(ModContent.ItemType<PearlquicksandBlock>());
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
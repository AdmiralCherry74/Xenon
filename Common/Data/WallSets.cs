using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Bricks;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.ForestMushroom;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.Other;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.Common.Data;

internal class WallSets
{

	public static bool[] CatacombWalls = WallID.Sets.Factory.CreateBoolSet(
	ModContent.WallType<RedCatacombWallUnsafe>(),
	ModContent.WallType<LavenderCatacombWallUnsafe>(),
	ModContent.WallType<CharcoalCatacombWallUnsafe>()
	);

	#region Conversion
	public static bool[] DungeonConvertWallBlue = WallID.Sets.Factory.CreateBoolSet(
		//Just using this for conversions
		WallID.BlueDungeonUnsafe
	);

	public static bool[] DungeonConvertWallTileBlue = WallID.Sets.Factory.CreateBoolSet(
		WallID.BlueDungeonTileUnsafe
	);

	public static bool[] DungeonConvertWallSlabBlue = WallID.Sets.Factory.CreateBoolSet(
		WallID.BlueDungeonSlabUnsafe
	);

	public static bool[] CatacombConvertWallLavender = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<LavenderCatacombWallUnsafe>()
	);

	public static bool[] CatacombConvertWallTileLavender = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<LavenderCatacombTileWallUnsafe>()
	);

	public static bool[] CatacombConvertWallSlabLavender = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<LavenderCatacombSlabWallUnsafe>()
	);

	public static bool[] DungeonConvertWallPink = WallID.Sets.Factory.CreateBoolSet(
		WallID.PinkDungeonUnsafe
	);

	public static bool[] DungeonConvertWallTilePink = WallID.Sets.Factory.CreateBoolSet(
		WallID.PinkDungeonTileUnsafe
	);

	public static bool[] DungeonConvertWallSlabPink = WallID.Sets.Factory.CreateBoolSet(
		WallID.PinkDungeonSlabUnsafe
	);

	public static bool[] CatacombConvertWallRed = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<RedCatacombWallUnsafe>()
	);

	public static bool[] CatacombConvertWallTileRed = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<RedCatacombTileWallUnsafe>()
	);

	public static bool[] CatacombConvertWallSlabRed = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<RedCatacombSlabWallUnsafe>()
	);

	public static bool[] DungeonConvertWallGreen = WallID.Sets.Factory.CreateBoolSet(
		WallID.GreenDungeonUnsafe
	);

	public static bool[] DungeonConvertWallTileGreen = WallID.Sets.Factory.CreateBoolSet(
		WallID.GreenDungeonTileUnsafe
	);

	public static bool[] DungeonConvertWallSlabGreen = WallID.Sets.Factory.CreateBoolSet(
		WallID.GreenDungeonSlabUnsafe
	);

	public static bool[] CatacombConvertWallCharcoal = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<CharcoalCatacombWallUnsafe>()
	);

	public static bool[] CatacombConvertWallTileCharcoal = WallID.Sets.Factory.CreateBoolSet(
	ModContent.WallType<CharcoalCatacombTileWallUnsafe>()
	);

    public static bool[] CatacombConvertWallSlabCharcoal = WallID.Sets.Factory.CreateBoolSet(
    ModContent.WallType<CharcoalCatacombSlabWallUnsafe>()
    );
    #endregion
}
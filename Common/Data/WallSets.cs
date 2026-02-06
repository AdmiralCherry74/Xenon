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
using Xenon.Content.Walls.BuildingWalls.Stones;
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

	public static bool[] CatacombConvertWallLavender = WallID.Sets.Factory.CreateBoolSet(
	ModContent.WallType<LavenderCatacombWallUnsafe>()
	);

	public static bool[] DungeonConvertWallPink = WallID.Sets.Factory.CreateBoolSet(
		WallID.PinkDungeonUnsafe
	);

	public static bool[] CatacombConvertWallRed = WallID.Sets.Factory.CreateBoolSet(
		ModContent.WallType<RedCatacombWallUnsafe>()
	);

	public static bool[] DungeonConvertWallGreen = WallID.Sets.Factory.CreateBoolSet(
		WallID.GreenDungeonUnsafe
	);

	public static bool[] CatacombConvertWallCharcoal = WallID.Sets.Factory.CreateBoolSet(
	ModContent.WallType<CharcoalCatacombWallUnsafe>()
	);
    #endregion
}
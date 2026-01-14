using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Mountains;
using System.Collections.Generic;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Weapons.Melee.Swords;
using Xenon.Content.Items.Weapons.Melee.YoYos;
using Xenon.Content.Items.Pets;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.WorldGeneration;

public class Utils
{
	public static int CliffsideItemCount;
	public static int CliffsideItemResult;
	public static int GetNextCliffsideChestItem()
	{
		//int result = ModContent.ItemType<Items.Accessories.PreHardmode.OilBottle>();
		//switch (HellfireItemCount % 2)
		//{
		//	case 0:
		//		result = ModContent.ItemType<Items.Accessories.PreHardmode.OilBottle>();
		//		break;
		//	case 1:
		//		result = ModContent.ItemType<Items.Tools.PreHardmode.EruptionHook>();
		//		break;
		//}

		//HellfireItemCount++;
		//return result;
		List<int> items = new()
		{
			ModContent.ItemType<ZephyrBoots>(),
			ModContent.ItemType<TheRange>(),
			ModContent.ItemType<SeedPacket>()
		};
		if (CliffsideItemCount % 2 == 0)
		{
			CliffsideItemResult = WorldGen.genRand.Next(items.Count);
			CliffsideItemCount++;
			return items[CliffsideItemResult];
		}
		else
		{
			List<int> excludeFirstItem = items;
			excludeFirstItem.Remove(excludeFirstItem[CliffsideItemResult]);
			int result2 = WorldGen.genRand.Next(excludeFirstItem.Count);
			CliffsideItemCount++;
			return excludeFirstItem[result2];
		}
	}

	/// <summary>
	/// A helper method to find the actual surface of the world.
	/// </summary>
	/// <param name="positionX">The x position.</param>
	/// <returns>The surface of the world.</returns>
	public static int TileCheck(int positionX)
    {
        for (int i = (int)(GenVars.worldSurfaceLow - 30); i < Main.maxTilesY; i++)
        {
            Tile tile = Framing.GetTileSafely(positionX, i);
            if ((tile.TileType == TileID.Dirt || tile.TileType == TileID.ClayBlock || tile.TileType == TileID.Stone ||
                tile.TileType == TileID.Sand || tile.TileType == ModContent.TileType<Gutsand>() ||
				tile.TileType == TileID.Mud ||
                tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock) && tile.HasTile)
            {
                return i - 3;
            }
        }
        return 0;
    }
    public static bool IsInsideEllipse(int x, int y, Vector2 center, int xRadius, int yRadius)
	{
		float dx = x - center.X;
		float dy = y - center.Y;
		return (dx * dx) / (xRadius * xRadius) + (dy * dy) / (yRadius * yRadius) <= 1;
	}

	public static void PlaceCustomTight(int x, int y, ushort type)
	{
		if (Main.tile[x, y].LiquidType != LiquidID.Shimmer)
		{
			PlaceUncheckedStalactite(x, y, WorldGen.genRand.NextBool(2), WorldGen.genRand.Next(3), type);
		}
	}

	public static void PlaceUncheckedStalactite(int x, int y, bool preferSmall, int variation, ushort type)
	{
		variation = Terraria.Utils.Clamp(variation, 0, 2);
		if (WorldGen.SolidTile(x, y - 1) && !Main.tile[x, y].HasTile && !Main.tile[x, y + 1].HasTile)
		{
			if (Main.tile[x, y - 1].TileType == ModContent.TileType<Tiles.Natural.Stone.Rhyolite>() ||
				Main.tile[x, y - 1].TileType == ModContent.TileType<FrozenLava>() ||
				Main.tile[x, y - 1].TileType == ModContent.TileType<Gutstone>())
			{
				if (preferSmall)
				{
					int num12 = variation * 18;
					Tile t = Main.tile[x, y];
					WorldGen.PlaceTile(x, y, type);
					t.TileFrameX = (short)num12;
					t.TileFrameY = 72;
				}
				else
				{
					int num15 = variation * 18;
					Tile t = Main.tile[x, y];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num15;
					t.TileFrameY = 0;
					t = Main.tile[x, y + 1];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num15;
					t.TileFrameY = 18;
				}
			}
		}
		else if (WorldGen.SolidTile(x, y + 1) && !Main.tile[x, y].HasTile && !Main.tile[x, y - 1].HasTile)
		{
			if (Main.tile[x, y + 1].TileType == ModContent.TileType<Tiles.Natural.Stone.Rhyolite>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<Gutstone>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<OuranoStone>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<NyxStone>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<HelioStone>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<HephStone>() ||
				Main.tile[x, y + 1].TileType == ModContent.TileType<AresStone>())
			{
				if (preferSmall)
				{
					int num5 = variation * 18;
					Tile t = Main.tile[x, y];
					t.TileType = type;
					t.HasTile = true;
					t.TileFrameX = (short)num5;
					t.TileFrameY = 90;
				}
				else
				{
					int num6 = variation * 18;
					Tile t = Main.tile[x, y - 1];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num6;
					t.TileFrameY = 36;
					t = Main.tile[x, y];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num6;
					t.TileFrameY = 54;
				}
			}
		}
	}
}

using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;
using System.Linq;
using System;
using Terraria.GameContent.Generation;
using Xenon.Content.Tiles.Furniture.Rhyolite;
using Terraria.Localization;

namespace Xenon.Content.WorldGeneration;

public class RhyoliteGen : ModSystem
{
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	{
		GenPass currentPass;
		int index = tasks.FindIndex(genPass => genPass.Name == "Shell Piles");
		if (index != -1)
		{
			currentPass = new RhyoliteGenPass();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Remove Broken Traps");
		if (index != -1)
		{
			currentPass = new RhyoliteStalac();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
	}
}
public class RhyoliteStalac : GenPass
{
	public RhyoliteStalac() : base("Rhyolite Stalac", 20f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		for (int num19 = 20; num19 < Main.maxTilesX - 20; num19++)
		{
			for (int num22 = 5; num22 < Main.maxTilesY - 20; num22++)
			{
				// rhyolite stalac
				if (Main.tile[num19, num22 - 1].TileType == ModContent.TileType<Tiles.Rhyolite>() && Main.tile[num19, num22 - 1].HasTile && WorldGen.genRand.NextBool(3))
				{
					if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 + 1].HasTile && Main.tile[num19, num22 - 1].Slope == SlopeType.Solid)
					{
						Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<Tiles.RhyoliteStalactgmites>());
					}
				}
				if (Main.tile[num19, num22 + 1].TileType == ModContent.TileType<Tiles.Rhyolite>() && Main.tile[num19, num22 + 1].HasTile && WorldGen.genRand.NextBool(3))
				{
					if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 - 1].HasTile && Main.tile[num19, num22 + 1].Slope == SlopeType.Solid)
					{
						Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<Tiles.RhyoliteStalactgmites>());
					}
				}
			}
		}
	}
}
public class RhyoliteGenPass : GenPass
{
	public RhyoliteGenPass() : base("Rhyolite", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Rhyolite");
		int ypos = Main.maxTilesY - 285;
		int xpos = WorldGen.genRand.Next(150, Main.maxTilesX / 2 - 250);
		int xpos2 = WorldGen.genRand.Next(Main.maxTilesX / 2 + 250, Main.maxTilesX - 150);
		WorldGenConfiguration config = WorldGenConfiguration.FromEmbeddedPath("Terraria.GameContent.WorldBuilding.Configuration.json");
		if (Rhyolite.PlaceRhyolite(xpos, ypos))
		{
			RhyoliteCabin cabin = config.CreateBiome<RhyoliteCabin>();
			int xpost = WorldGen.genRand.Next(xpos - 10, xpos + 20);
			int ypost = WorldGen.genRand.Next(ypos + 10, ypos + 50);
			cabin.Place(new Point(xpost, ypost), null);
		}
		if (Rhyolite.PlaceRhyolite(xpos2, ypos))
		{
			RhyoliteCabin cabin = config.CreateBiome<RhyoliteCabin>();
			int xpost = WorldGen.genRand.Next(xpos2 - 10, xpos2 + 20);
			int ypost = WorldGen.genRand.Next(ypos + 10, ypos + 50);
			cabin.Place(new Point(xpost, ypost), null);
		}
	}
}
public class Rhyolite
{
	/// <summary>
	/// Generation method for Rhyolite cave.
	/// </summary>
	/// <param name="x">The X coordinate to place the biome at (the middle of the biome)</param>
	/// <param name="y">The Y coordinate to place the biome at (the top of the biome)</param>
	public static bool PlaceRhyolite(int x, int y)
	{
		ushort tile = (ushort)ModContent.TileType<Tiles.Rhyolite>();
		ushort wall = (ushort)ModContent.WallType<Walls.RhyoliteWallUnsafe>();

		int randWidth = WorldGen.genRand.Next(40, 52);
		int height = 85;

		GetRhyoliteXCoord(x, y, randWidth * 2, height, ref x);

		// save the existing tiles
		List<int> savedRandoms = new List<int>();
		List<ushort> savedTiles = new List<ushort>();
		List<bool> savedActive = new List<bool>();
		for (int topX = x - randWidth; topX < x + randWidth; topX++)
		{
			for (int topY = y; topY >= y - 8; topY--)
			{
				savedRandoms.Add(0);
				savedTiles.Add(0);
				savedActive.Add(false);

			}
		}
		int counter = 0;
		for (int topX = x - randWidth; topX < x + randWidth; topX++)
		{
			for (int topY = y; topY >= y - 8; topY--)
			{
				int rn = WorldGen.genRand.Next(3);
				savedRandoms[counter] = rn;
				if (topY < y - rn)
				{
					savedTiles[counter] = Main.tile[topX, topY].TileType;
					savedActive[counter] = Main.tile[topX, topY].HasTile;
				}
				counter++;
			}
		}

		// place the main cone and the lava inside the walls
		int pstep = randWidth;
		for (int pyY = y; pyY <= y + height; pyY += 4)
		{
			for (int pyX = x - pstep - 1 - 5; pyX < x + pstep + 5; pyX++)
			{
				Tile t = Main.tile[pyX + 1, pyY];
				t.LiquidAmount = 0;
				t = Main.tile[pyX + 1, pyY - 1];
				t.LiquidAmount = 0;
				t = Main.tile[pyX + 1, pyY - 2];
				t.LiquidAmount = 0;
				t = Main.tile[pyX + 1, pyY - 3];
				t.LiquidAmount = 0;
				if (pyX > x - pstep - 1 && pyX < x + pstep)
				{
					if (pyX > x - pstep && pyX < x + pstep - 1)
					{
						Main.tile[pyX + 1, pyY].WallType = wall;
						Main.tile[pyX + 1, pyY - 1].WallType = wall;
						Main.tile[pyX + 1, pyY - 2].WallType = wall;
						Main.tile[pyX + 1, pyY - 3].WallType = wall;
						WorldGen.SquareWallFrame(pyX + 1, pyY);
						WorldGen.SquareWallFrame(pyX + 1, pyY - 1);
						WorldGen.SquareWallFrame(pyX + 1, pyY - 2);
						WorldGen.SquareWallFrame(pyX + 1, pyY - 3);
					}

					WorldGen.PlaceTile(pyX + 1, pyY, tile, mute: true, forced: true);
					WorldGen.SquareTileFrame(pyX + 1, pyY);
					WorldGen.PlaceTile(pyX + 1, pyY - 1, tile, mute: true, forced: true);
					WorldGen.SquareTileFrame(pyX + 1, pyY - 1);
					WorldGen.PlaceTile(pyX + 1, pyY - 2, tile, mute: true, forced: true);
					WorldGen.SquareTileFrame(pyX + 1, pyY - 2);
					WorldGen.PlaceTile(pyX + 1, pyY - 3, tile, mute: true, forced: true);
					WorldGen.SquareTileFrame(pyX + 1, pyY - 3);

					// destroy the tunnel area and place walls
					if (pyX > x - randWidth + 15 - pstep + randWidth && pyX < x + randWidth - 15 + pstep - randWidth)
					{
						WorldGen.KillTile(pyX + 1, pyY);
						WorldGen.KillTile(pyX + 1, pyY - 1);
						WorldGen.KillTile(pyX + 1, pyY - 2);
						WorldGen.KillTile(pyX + 1, pyY - 3);

						if (pyY == y)
						{
							WorldGen.KillWall(pyX + 1, pyY);
							WorldGen.KillWall(pyX + 1, pyY - 1);
							WorldGen.KillWall(pyX + 1, pyY - 2);
							WorldGen.PlaceWall(pyX + 1, pyY, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 1, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 2, wall, mute: true);
						}
						else if (pyY == y + height)
						{
							WorldGen.KillWall(pyX + 1, pyY - 1);
							WorldGen.KillWall(pyX + 1, pyY - 2);
							WorldGen.KillWall(pyX + 1, pyY - 3);

							WorldGen.PlaceWall(pyX + 1, pyY - 1, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 2, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 3, wall, mute: true);
						}
						else
						{
							WorldGen.KillWall(pyX + 1, pyY);
							WorldGen.KillWall(pyX + 1, pyY - 1);
							WorldGen.KillWall(pyX + 1, pyY - 2);
							WorldGen.KillWall(pyX + 1, pyY - 3);

							WorldGen.PlaceWall(pyX + 1, pyY, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 1, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 2, wall, mute: true);
							WorldGen.PlaceWall(pyX + 1, pyY - 3, wall, mute: true);
						}
					}
					else
					{
						// place lava blobs in the walls at a 1 in 5 chance per tile
						if (WorldGen.genRand.NextBool(5))
						{
							PlaceLavaBlob(pyX + 1, pyY);
						}
					}

					// make the interior of the tunnel more random in appearance
					if ((pyX < x - randWidth + 15 - pstep + randWidth + WorldGen.genRand.Next(4) + 1 && pyX > x - pstep - 1) || (pyX > x + randWidth - 15 + pstep - randWidth - WorldGen.genRand.Next(4) + 1 && pyX < x + pstep))
					{
						WorldGen.PlaceTile(pyX + 1, pyY, tile, mute: true, forced: true);
					}
					if ((pyX < x - randWidth + 15 - pstep + randWidth + WorldGen.genRand.Next(4) + 1 && pyX > x - pstep - 1) || (pyX > x + randWidth - 15 + pstep - randWidth - WorldGen.genRand.Next(4) + 1 && pyX < x + pstep))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 1, tile, mute: true, forced: true);
					}
					if ((pyX < x - randWidth + 15 - pstep + randWidth + WorldGen.genRand.Next(4) + 1 && pyX > x - pstep - 1) || (pyX > x + randWidth - 15 + pstep - randWidth - WorldGen.genRand.Next(4) + 1 && pyX < x + pstep))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 2, tile, mute: true, forced: true);
					}
					if ((pyX < x - randWidth + 15 - pstep + randWidth + WorldGen.genRand.Next(4) + 1 && pyX > x - pstep - 1) || (pyX > x + randWidth - 15 + pstep - randWidth - WorldGen.genRand.Next(4) + 1 && pyX < x + pstep))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 3, tile, mute: true, forced: true);
					}
				}
				else
				{
					// make the exterior of the tunnel more random in appearance
					if ((pyX <= x - pstep - 1 && pyX >= x - pstep - WorldGen.genRand.Next(4) + 1) || (pyX >= x + pstep && pyX <= x + pstep + WorldGen.genRand.Next(4) + 1))
					{
						WorldGen.PlaceTile(pyX + 1, pyY, tile, mute: true, forced: true);
					}
					if ((pyX <= x - pstep - 1 && pyX >= x - pstep - WorldGen.genRand.Next(4) + 1) || (pyX >= x + pstep && pyX <= x + pstep + WorldGen.genRand.Next(4) + 1))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 1, tile, mute: true, forced: true);
					}
					if ((pyX <= x - pstep - 1 && pyX >= x - pstep - WorldGen.genRand.Next(4) + 1) || (pyX >= x + pstep && pyX <= x + pstep + WorldGen.genRand.Next(4) + 1))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 2, tile, mute: true, forced: true);
					}
					if ((pyX <= x - pstep - 1 && pyX >= x - pstep - WorldGen.genRand.Next(4) + 1) || (pyX >= x + pstep && pyX <= x + pstep + WorldGen.genRand.Next(4) + 1))
					{
						WorldGen.PlaceTile(pyX + 1, pyY - 3, tile, mute: true, forced: true);
					}
				}
				// remove the top and bottom layers of walls
				if (pyY == y + height - 1)
				{
					WorldGen.KillWall(pyX + 1, pyY);
				}
				if (pyY == y)
				{
					WorldGen.KillWall(pyX + 1, pyY - 3);
				}
			}
			pstep++;
		}

		pstep = randWidth;
		for (int pyY = y; pyY <= y + height; pyY += 4)
		{
			for (int pyX = x - pstep - 1 - 5; pyX < x + pstep + 5; pyX++)
			{
				if (pyX > x - pstep - 1 && pyX < x + pstep)
				{
					if (pyX > x - randWidth + 15 - pstep + randWidth && pyX < x + randWidth - 15 + pstep - randWidth)
					{
					}
					else
					{
						// place lava blobs in the walls at a 1 in 5 chance per tile
						if (WorldGen.genRand.NextBool(8))
						{
							PlaceLavaBlob(pyX + 1, pyY);
						}
					}
				}
			}
			pstep++;
		}

		// save pstep for later use for unevenifying the bottom
		int pstepSaved = pstep;

		// hollow out the space below the biome, to open it up to hell
		for (int z = y + height; z <= y + height + 35; z += 2)
		{
			for (int q = x - pstep; q <= x + pstep; q++)
			{
				Tile t2 = Main.tile[q, z];
				if (t2.TileType is not TileID.ObsidianBrick and not TileID.AncientObsidianBrick and not TileID.AncientHellstoneBrick and not TileID.HellstoneBrick || !Main.tileFrameImportant[t2.TileType])
				{
					WorldGen.KillTile(q, z);
					WorldGen.KillTile(q, z - 1);
				}
				if (t2.WallType is not WallID.ObsidianBrickUnsafe and not WallID.HellstoneBrickUnsafe)
				{
					WorldGen.KillWall(q, z);
					WorldGen.KillWall(q, z - 1);
				}
			}
			pstep++;
		}

		List<Rectangle> rectangles = new List<Rectangle>();
		// place small lava pools
		for (int numThingies = 0; numThingies < 20; numThingies++)
		{
			Vector2 pos = WorldGen.genRand.NextVector2FromRectangle(new(x - randWidth + 18, y + 5, randWidth * 2 - 36, height - 28));
			for (int q = 0; q < 10; q++)
			{
				if (IsRectangleTooClose(new Rectangle((int)pos.X - 5, (int)pos.Y, 11, 7), rectangles, 3))
				{
					pos = WorldGen.genRand.NextVector2FromRectangle(new(x - randWidth + 18, y + 5, randWidth * 2 - 36, height - 28));
				}
				else break;
			}

			rectangles.Add(PlaceFloatingLavaPool((int)pos.X, (int)pos.Y, tile));
		}

		LargeLavaPool(x, y + height - 12, tile);

		counter = 0;
		// unevenify the top 
		for (int topX = x - randWidth; topX < x + randWidth; topX++)
		{
			for (int topY = y; topY >= y - 8; topY--)
			{
				if (topY < y - savedRandoms[counter])
				{
					if (Main.tile[topX, topY].TileType == tile)
					{
						WorldGen.KillTile(topX, topY, noItem: true);
						WorldGen.KillWall(topX, topY);
						KillDirectionsWalls(topX, topY);
					}
					else
					{
						WorldGen.KillWall(topX, topY);
						KillDirectionsWalls(topX, topY);
					}
				}
				counter++;
			}
		}

		counter = 0;
		for (int topX = x - randWidth; topX < x + randWidth; topX++)
		{
			for (int topY = y; topY >= y - 8; topY--)
			{
				if (topY < y - savedRandoms[counter])
				{
					Tile t = Main.tile[topX, topY];
					t.HasTile = savedActive[counter];
					t.TileType = savedTiles[counter];
					WorldGen.SquareTileFrame(topX, topY);
				}
				counter++;
			}
		}

		// unevenify the bottom
		for (int bottomX = x - (randWidth + 22); bottomX < x + (randWidth + 22); bottomX++)
		{
			for (int bottomY = y + height; bottomY >= y + (height - 8); bottomY--)
			{
				if (bottomY > y + (height - WorldGen.genRand.Next(3) - 4))
				{
					//if (Main.tile[bottomX, bottomY].TileType == tile)
					{
						WorldGen.KillTile(bottomX, bottomY, noItem: true);
						WorldGen.KillWall(bottomX, bottomY);
						KillDirectionsWalls(bottomX, bottomY);
					}
				}
			}
		}

		return true;
	}
	private static void KillDirectionsWalls(int x, int y)
	{
		WorldGen.KillWall(x - 1, y);
		WorldGen.KillWall(x, y - 1);
		WorldGen.KillWall(x + 1, y);
		WorldGen.KillWall(x, y + 1);
	}
	/// <summary>
	/// Helper method to check if a rectangle is inside another Rectangle.
	/// </summary>
	/// <param name="r1">The Rectangle to check.</param>
	/// <param name="rectangles">A list containing a bunch of Rectangles.</param>
	/// <param name="minDist">The padding on all sides of the Rectangle to use.</param>
	/// <returns>Whether the Rectangle intersects any of the Rectangles in the list.</returns>
	private static bool IsRectangleTooClose(Rectangle r1, List<Rectangle> rectangles, int minDist = 5)
	{
		foreach (Rectangle rect in rectangles)
		{
			if (rect.Intersects(r1.Expand(minDist, minDist)))
			{
				return true;
			}
		}
		return false;
	}
	private static void MakeEllipse(int x, int y, int xRadius, int yRadius, int type)
	{
		int xmin = x - xRadius;
		int ymin = y - yRadius;
		int xmax = x + xRadius;
		int ymax = y + yRadius;
		for (int i = xmin; i < xmax + 1; i++)
		{
			for (int j = ymin; j < ymax + 1; j++)
			{
				if (WorldGeneration.Utils.IsInsideEllipse(i, j, new Vector2(x, y), xRadius, yRadius))
				{
					Tile q = Main.tile[i, j];
					if (type == 65535)
					{
						Tile t = Main.tile[i, j];
						t.HasTile = false;
						WorldGen.SquareTileFrame(i, j);
						t.LiquidType = LiquidID.Lava;
						t.LiquidAmount = 50;
					}
					else
					{
						q.HasTile = true;
						q.TileType = (ushort)type;
						WorldGen.SquareTileFrame(i, j);
					}
				}
			}
		}
	}
	/// <summary>
	/// Generates a large lava pool using 2 ellipses.
	/// </summary>
	/// <param name="x">The X coordinate of the middle of the lava pool.</param>
	/// <param name="y">The Y coordinate of the middle of the lava pool.</param>
	/// <param name="type">The tile to place.</param>
	private static void LargeLavaPool(int x, int y, int type)
	{
		int xRad = WorldGen.genRand.Next(15, 21);
		int xRadAir = WorldGen.genRand.Next(13, 19);
		int yRad = 5;

		MakeEllipse(x, y, xRad, yRad, type);
		MakeEllipse(x, y - 4, xRadAir, yRad, ushort.MaxValue);
	}
	/// <summary>
	/// Places a lava blob.
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	private static void PlaceLavaBlob(int x, int y)
	{
		for (int i = x - WorldGen.genRand.Next(2) + 1; i < x + WorldGen.genRand.Next(2) + 1; i++)
		{
			for (int j = y - WorldGen.genRand.Next(3) + 1; j < y + WorldGen.genRand.Next(3) + 1; j++)
			{
				WorldGen.KillTile(i, j);
				Tile t = Main.tile[i, j];
				t.LiquidType = LiquidID.Lava;
				t.LiquidAmount = (byte)WorldGen.genRand.Next(200, 255);
			}
		}
	}
	/// <summary>
	/// Generates a floating lava pool with 1 of 2 sizes.
	/// </summary>
	/// <param name="x">The middle of the pool.</param>
	/// <param name="y">The top of the pool.</param>
	/// <param name="tileType">The tile to make the solid blocks out of.</param>
	/// <returns>A rectangle that contains the pool.</returns>
	private static Rectangle PlaceFloatingLavaPool(int x, int y, int tileType)
	{
		int rn = WorldGen.genRand.Next(2);
		if (rn == 0)
		{
			for (int i = x - 3; i <= x + 3; i++)
			{
				for (int j = y; j < y + 3; j++)
				{
					if (j == y + 1)
					{
						if (WorldGen.genRand.NextBool(2))
						{
							if (i != x - 3)
							{
								WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
							}
						}
						else
						{
							if (i != x + 3)
							{
								WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
							}
						}
					}
					if (j == y)
					{
						if (i < x - 2 || i > x + 2)
						{
							WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
						}
						if (WorldGen.genRand.NextBool())
						{
							Tile t = Main.tile[x + 2, j];
							t.IsHalfBlock = true;
						}
						else
						{
							Tile t = Main.tile[x - 2, j];
							t.IsHalfBlock = true;
						}
						if (i >= x - 1 && i <= x + 1)
						{
							Tile t = Main.tile[i, j];
							t.LiquidType = LiquidID.Lava;
							t.LiquidAmount = 255;
						}
					}
					if (j == y + 2)
					{
						WorldGen.PlaceTile(x, j, tileType, mute: true, forced: true);
						if (WorldGen.genRand.NextBool())
						{
							WorldGen.PlaceTile(x + 1, j, tileType, mute: true, forced: true);
						}
						else
						{
							WorldGen.PlaceTile(x - 1, j, tileType, mute: true, forced: true);
						}
					}
				}
			}
			return new(x - 3, y, 7, 3);
		}
		else
		{
			for (int i = x - 4; i <= x + 4; i++)
			{
				for (int j = y; j < y + 5; j++)
				{
					if ((i == x - 4 || i == x + 4) && j == y)
					{
						WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
					}
					if (WorldGen.genRand.NextBool())
					{
						if ((i <= x - 3 || i == x + 4) && j == y + 1)
						{
							WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
						}
					}
					else
					{
						if ((i == x - 4 || i >= x + 3) && j == y + 1)
						{
							WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
						}
					}
					if (WorldGen.genRand.NextBool())
					{
						if ((i <= x - 3 || (i >= x + 1 && i <= x + 3)) && j == y + 2)
						{
							WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
						}
					}
					else
					{
						if ((i >= x + 3 || (i <= x - 1 && i >= x - 3)) && j == y + 2)
						{
							WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
						}
					}
					if (j == y + 3 && i > x - 4 && i < x + 4)
					{
						WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
					}
					if (j == y + 4 && i > x - 1 && i < x + 1)
					{
						WorldGen.PlaceTile(i, j, tileType, mute: true, forced: true);
					}

					// lava placement
					if ((i > x - 4 && i < x + 4 && j == y) ||
						(i > x - 3 && i < x + 3 && j == y + 1) ||
						(i == x && j == y + 2))
					{
						Tile t = Main.tile[i, j];
						t.LiquidType = LiquidID.Lava;
						t.LiquidAmount = (byte)(j == y ? 50 : 255);
					}
				}
			}
			return new(x - 4, y, 9, 5);
		}
	}

	/// <summary>
	/// Helper method to shift the biome left or right depending on if there's granite/marble/dungeon bricks in the way.
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="xLength"></param>
	/// <param name="yLength"></param>
	/// <param name="xCoord"></param>
	public static void GetRhyoliteXCoord(int x, int y, int xLength, int yLength, ref int xCoord)
	{
		bool leftSideActive = false;
		bool rightSideActive = false;

		for (int i = y; i < y + yLength; i++)
		{
			if (Main.tile[x, i].HasTile && (Main.tile[x, i].TileType is TileID.Granite or TileID.Marble) || (Main.tile[x, i].WallType is WallID.MarbleUnsafe or WallID.GraniteUnsafe) || Main.tileDungeon[Main.tile[x, i].TileType])
			{
				leftSideActive = true;
				break;
			}
		}

		for (int i = y; i < y + yLength; i++)
		{
			if (Main.tile[x + xLength, i].HasTile && (Main.tile[x + xLength, i].TileType is TileID.Granite or TileID.Marble) || (Main.tile[x + xLength, i].WallType is WallID.MarbleUnsafe or WallID.GraniteUnsafe) || Main.tileDungeon[Main.tile[x + xLength, i].TileType])
			{
				rightSideActive = true;
				break;
			}
		}

		if (leftSideActive || rightSideActive)
		{
			if (xCoord > Main.maxTilesX / 2) xCoord++;
			else if (xCoord < Main.maxTilesX / 2) xCoord--;
			else return;
			if (xCoord < 100)
			{
				xCoord = 100;
				return;
			}
			if (xCoord > Main.maxTilesX - 100)
			{
				xCoord = Main.maxTilesX - 100;
				return;
			}
			GetRhyoliteXCoord(x, y, xLength, yLength, ref xCoord);
		}
	}

	/// <summary>
	/// Old Rhyolite cave generation method.
	/// </summary>
	/// <param name="x">X coord of the top middle.</param>
	/// <param name="y">Y coord of the top middle.</param>
	private static void PlaceRhyoliteOld(int x, int y)
	{
		ushort tile = TileID.Adamantite;
		ushort wall = WallID.RichMaogany;

		int randWidth = WorldGen.genRand.Next(25, 34);
		int randHeight = WorldGen.genRand.Next(50, 75);

		for (int i = x - randWidth - 4; i <= x + randWidth + 4; i++)
		{
			for (int j = y; j <= y + randHeight; j++)
			{
				Main.tile[i, j].LiquidAmount = 0;
				if (i < x - randWidth && i >= x - randWidth - WorldGen.genRand.Next(4) + 1)
				{
					WorldGen.PlaceTile(i, j, tile, forced: true);
				}
				if (i >= x + randWidth && i <= x + randWidth + WorldGen.genRand.Next(4) + 1)
				{
					WorldGen.PlaceTile(i, j, tile, forced: true);
				}
			}
		}

		for (int i = x - randWidth; i <= x + randWidth; i++)
		{
			for (int j = y; j <= y + randHeight; j++)
			{
				if (j > y && j < y + randHeight && i > x - randWidth && i < x + randWidth)
				{
					Main.tile[i, j].WallType = wall;
					WorldGen.SquareWallFrame(i, j);
				}
				if (i < x - randWidth + WorldGen.genRand.Next(10, 13) || i >= x + randWidth - WorldGen.genRand.Next(10, 13))
				{
					WorldGen.PlaceTile(i, j, tile, forced: true);
					WorldGen.SquareTileFrame(i, j);
					if (j % WorldGen.genRand.Next(10, 16) == 0)
					{
						PlaceLavaBlob(i, j);
					}
				}
				else
				{
					WorldGen.KillTile(i, j, noItem: true);
				}
			}
		}

		for (int numThingies = 0; numThingies < 8; numThingies++)
		{
			Vector2 pos = WorldGen.genRand.NextVector2FromRectangle(new(x - randWidth + 14, y + 5, randWidth * 2 - 28, randHeight - 20));
			PlaceFloatingLavaPool((int)pos.X, (int)pos.Y, tile);
		}
		for (int i = x - randWidth; i <= x + randWidth; i++)
		{
			for (int j = y + randHeight; j <= y + randHeight + 8; j++)
			{
				if (j > y + randHeight && j < y + randHeight + 8 && i > x - randWidth && i < x + randWidth)
				{
					WorldGen.PlaceWall(i, j, wall);
					Tile t = Main.tile[i, j];
					t.LiquidType = LiquidID.Lava;
					t.LiquidAmount = 255;
				}
				WorldGen.PlaceTile(i, j, tile, forced: true);
				WorldGen.SquareTileFrame(i, j);
			}
		}

		int pstep = randWidth;
		int counter = 0;
		for (int pyY = y + randHeight + 8; pyY <= y + randHeight + 23; pyY += 1)
		{
			if (counter > 9) continue;
			for (int pyX = x - pstep - 1; pyX < x + pstep; pyX += 1)
			{
				WorldGen.PlaceTile(pyX + 1, pyY, tile, forced: true);
				WorldGen.SquareTileFrame(pyX + 1, pyY);

				if (pyX > x - randWidth + 10 && pyX < x + randWidth - 10)
				{
					WorldGen.KillTile(pyX + 1, pyY - 10);
					Tile t = Main.tile[pyX + 1, pyY - 10];
					t.LiquidType = LiquidID.Lava;
					t.LiquidAmount = 255;
				}
			}
			counter++;
			if (counter < 4) pstep--;
			if (counter < 7) pstep--;
			if (counter < 9) pstep--;
			if (counter < 10) pstep--;
		}
	}
}
public class RhyoliteCabin : MicroBiome
{
	private class BuildData
	{
		public delegate void ProcessRoomMethod(Rectangle room);

		public static BuildData Rhyolite = CreateRhyoliteData();

		public static BuildData Default = CreateDefaultData();

		public ushort Tile;

		public ushort Wall;

		public int PlatformStyle;

		public int DoorStyle;

		public int TableStyle;

		public int WorkbenchStyle;

		public int PianoStyle;

		public int BookcaseStyle;

		public int ChairStyle;

		public int ChestStyle;

		public ProcessRoomMethod ProcessRoom;

		public static BuildData CreateRhyoliteData()
		{
			return new BuildData
			{
				Tile = (ushort)ModContent.TileType<Tiles.SmoothRhyolite>(),
				Wall = (ushort)ModContent.WallType<Walls.SmoothRhyoliteWallUnsafe>(),
				DoorStyle = 0,
				PlatformStyle = 0,
				TableStyle = 0,
				WorkbenchStyle = 0,
				PianoStyle = 0,
				BookcaseStyle = 0,
				ChairStyle = 0,
				ChestStyle = 0,
				ProcessRoom = AgeRoom
			};
		}

		public static BuildData CreateDefaultData()
		{
			return new BuildData
			{
				Tile = 30,
				Wall = 27,
				PlatformStyle = 0,
				DoorStyle = 0,
				TableStyle = 0,
				WorkbenchStyle = 0,
				PianoStyle = 0,
				BookcaseStyle = 0,
				ChairStyle = 0,
				ChestStyle = 1,
				ProcessRoom = AgeDefaultRoom
			};
		}
	}

	private const int VERTICAL_EXIT_WIDTH = 3;

	public static bool[] _blacklistedTiles = TileID.Sets.Factory.CreateBoolSet(true, 225, 41, 43, 44, 226, 203, 112, 25, 151);
	public static int[] blacklistedWalls =
	{
		WallID.BlueDungeonSlabUnsafe,
		WallID.BlueDungeonTileUnsafe,
		WallID.BlueDungeonUnsafe,
		WallID.GreenDungeonSlabUnsafe,
		WallID.GreenDungeonTileUnsafe,
		WallID.GreenDungeonUnsafe,
		WallID.PinkDungeonSlabUnsafe,
		WallID.PinkDungeonTileUnsafe,
		WallID.PinkDungeonUnsafe,
		WallID.LihzahrdBrickUnsafe,
	};

	private Rectangle GetRoom(Point origin)
	{
		Point result;
		bool flag = WorldUtils.Find(origin, Searches.Chain(new Searches.Left(25), new Conditions.IsSolid()), out result);
		Point result2;
		bool num = WorldUtils.Find(origin, Searches.Chain(new Searches.Right(25), new Conditions.IsSolid()), out result2);
		if (!flag)
		{
			result = new Point(origin.X - 25, origin.Y);
		}
		if (!num)
		{
			result2 = new Point(origin.X + 25, origin.Y);
		}
		Rectangle result3 = new Rectangle(origin.X, origin.Y, 0, 0);
		if (origin.X - result.X > result2.X - origin.X)
		{
			result3.X = result.X;
			result3.Width = Terraria.Utils.Clamp(result2.X - result.X, 15, 30);
		}
		else
		{
			result3.Width = Terraria.Utils.Clamp(result2.X - result.X, 15, 30);
			result3.X = result2.X - result3.Width;
		}
		Point result4;
		bool flag2 = WorldUtils.Find(result, Searches.Chain(new Searches.Up(10), new Conditions.IsSolid()), out result4);
		Point result5;
		bool num2 = WorldUtils.Find(result2, Searches.Chain(new Searches.Up(10), new Conditions.IsSolid()), out result5);
		if (!flag2)
		{
			result4 = new Point(origin.X, origin.Y - 10);
		}
		if (!num2)
		{
			result5 = new Point(origin.X, origin.Y - 10);
		}
		result3.Height = Terraria.Utils.Clamp(Math.Max(origin.Y - result4.Y, origin.Y - result5.Y), 8, 12);
		result3.Y -= result3.Height;
		return result3;
	}

	private float RoomSolidPrecentage(Rectangle room)
	{
		float num = room.Width * room.Height;
		Ref<int> @ref = new Ref<int>(0);
		WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new Modifiers.IsSolid(), new Actions.Count(@ref)));
		return (float)@ref.Value / num;
	}

	private bool FindVerticalExit(Rectangle wall, bool isUp, out int exitX)
	{
		Point result;
		bool result2 = WorldUtils.Find(new Point(wall.X + wall.Width - 3, wall.Y + (isUp ? (-5) : 0)), Searches.Chain(new Searches.Left(wall.Width - 3), new Conditions.IsSolid().Not().AreaOr(3, 5)), out result);
		exitX = result.X;
		return result2;
	}

	private bool FindSideExit(Rectangle wall, bool isLeft, out int exitY)
	{
		Point result;
		bool result2 = WorldUtils.Find(new Point(wall.X + (isLeft ? (-4) : 0), wall.Y + wall.Height - 3), Searches.Chain(new Searches.Up(wall.Height - 3), new Conditions.IsSolid().Not().AreaOr(4, 3)), out result);
		exitY = result.Y;
		return result2;
	}

	private int SortBiomeResults(Tuple<BuildData, int> item1, Tuple<BuildData, int> item2)
	{
		return item2.Item2.CompareTo(item1.Item2);
	}

	public override bool Place(Point origin, StructureMap structures)
	{
		if (!WorldUtils.Find(origin, Searches.Chain(new Searches.Down(200), new Conditions.IsSolid()), out var result) || result == origin)
		{
			return false;
		}
		Rectangle room = GetRoom(result);
		Rectangle rectangle = GetRoom(new Point(room.Center.X, room.Y + 1));
		Rectangle rectangle2 = GetRoom(new Point(room.Center.X, room.Y + room.Height + 10));
		rectangle2.Y = room.Y + room.Height - 1;
		float num = RoomSolidPrecentage(rectangle);
		float num13 = RoomSolidPrecentage(rectangle2);
		room.Y += 3;
		rectangle.Y += 3;
		rectangle2.Y += 3;
		List<Rectangle> list = new List<Rectangle>();
		if (_random.NextFloat() > num + 0.2f)
		{
			list.Add(rectangle);
		}
		else
		{
			rectangle = room;
		}
		list.Add(room);
		if (_random.NextFloat() > num13 + 0.2f)
		{
			list.Add(rectangle2);
		}
		else
		{
			rectangle2 = room;
		}
		foreach (Rectangle item12 in list)
		{
			if (item12.Y + item12.Height > Main.maxTilesY - 220)
			{
				return false;
			}
		}
		Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
		foreach (Rectangle item13 in list)
		{
			WorldUtils.Gen(new Point(item13.X - 10, item13.Y - 10), new Shapes.Rectangle(item13.Width + 20, item13.Height + 20), new Actions.TileScanner(0, (ushort)ModContent.TileType<Tiles.SmoothRhyolite>(), (ushort)ModContent.TileType<Tiles.Rhyolite>()).Output(dictionary));
		}
		List<Tuple<BuildData, int>> list6 = [Tuple.Create(BuildData.Rhyolite, dictionary[(ushort)ModContent.TileType<Tiles.Rhyolite>()] + dictionary[(ushort)ModContent.TileType<Tiles.SmoothRhyolite>()])];
		list6.Sort(SortBiomeResults);
		BuildData item = list6[0].Item1;
		//foreach (Rectangle item14 in list)
		//{
		//    if (!structures.CanPlace(item14, _blacklistedTiles, 5))
		//    {
		//        return false;
		//    }
		//}

		for (int left = room.X; left < room.X + room.Width - 1; left++)
		{
			for (int top = room.Y; top < room.Y + room.Height - 1; top++)
			{
				if (blacklistedWalls.Contains(Main.tile[left, top].WallType))
				{
					return false;
				}
			}
		}
		int num24 = room.X;
		int num33 = room.X + room.Width - 1;
		List<Rectangle> list2 = new List<Rectangle>();
		foreach (Rectangle item15 in list)
		{
			num24 = Math.Min(num24, item15.X);
			num33 = Math.Max(num33, item15.X + item15.Width - 1);
		}
		int num34 = 6;
		while (num34 > 4 && (num33 - num24) % num34 != 0)
		{
			num34--;
		}
		for (int i = num24; i <= num33; i += num34)
		{
			for (int j = 0; j < list.Count; j++)
			{
				Rectangle rectangle3 = list[j];
				if (i < rectangle3.X || i >= rectangle3.X + rectangle3.Width)
				{
					continue;
				}
				int num35 = rectangle3.Y + rectangle3.Height;
				int num36 = 50;
				for (int k = j + 1; k < list.Count; k++)
				{
					if (i >= list[k].X && i < list[k].X + list[k].Width)
					{
						num36 = Math.Min(num36, list[k].Y - num35);
					}
				}
				if (num36 > 0)
				{
					Point result2;
					bool flag = WorldUtils.Find(new Point(i, num35), Searches.Chain(new Searches.Down(num36), new Conditions.IsSolid()), out result2);
					if (num36 < 50)
					{
						flag = true;
						result2 = new Point(i, num35 + num36);
					}
					if (flag)
					{
						list2.Add(new Rectangle(i, num35, 1, result2.Y - num35));
					}
				}
			}
		}
		List<Point> list3 = new List<Point>();
		foreach (Rectangle item16 in list)
		{
			if (FindSideExit(new Rectangle(item16.X + item16.Width, item16.Y + 1, 1, item16.Height - 2), isLeft: false, out var exitY))
			{
				list3.Add(new Point(item16.X + item16.Width - 1, exitY));
			}
			if (FindSideExit(new Rectangle(item16.X, item16.Y + 1, 1, item16.Height - 2), isLeft: true, out exitY))
			{
				list3.Add(new Point(item16.X, exitY));
			}
		}
		List<Tuple<Point, Point>> list4 = new List<Tuple<Point, Point>>();
		for (int l = 1; l < list.Count; l++)
		{
			Rectangle rectangle4 = list[l];
			Rectangle rectangle5 = list[l - 1];
			int num38 = rectangle5.X - rectangle4.X;
			int num37 = rectangle4.X + rectangle4.Width - (rectangle5.X + rectangle5.Width);
			if (num38 > num37)
			{
				list4.Add(new Tuple<Point, Point>(new Point(rectangle4.X + rectangle4.Width - 1, rectangle4.Y + 1), new Point(rectangle4.X + rectangle4.Width - rectangle4.Height + 1, rectangle4.Y + rectangle4.Height - 1)));
			}
			else
			{
				list4.Add(new Tuple<Point, Point>(new Point(rectangle4.X, rectangle4.Y + 1), new Point(rectangle4.X + rectangle4.Height - 1, rectangle4.Y + rectangle4.Height - 1)));
			}
		}
		List<Point> list5 = new List<Point>();
		if (FindVerticalExit(new Rectangle(rectangle.X + 2, rectangle.Y, rectangle.Width - 4, 1), isUp: true, out var exitX))
		{
			list5.Add(new Point(exitX, rectangle.Y));
		}
		if (FindVerticalExit(new Rectangle(rectangle2.X + 2, rectangle2.Y + rectangle2.Height - 1, rectangle2.Width - 4, 1), isUp: false, out exitX))
		{
			list5.Add(new Point(exitX, rectangle2.Y + rectangle2.Height - 1));
		}
		foreach (Rectangle item17 in list)
		{
			WorldUtils.Gen(new Point(item17.X, item17.Y), new Shapes.Rectangle(item17.Width, item17.Height), Actions.Chain(new Actions.SetTile(item.Tile), new Actions.SetFrames(frameNeighbors: true)));
			WorldUtils.Gen(new Point(item17.X + 1, item17.Y + 1), new Shapes.Rectangle(item17.Width - 2, item17.Height - 2), Actions.Chain(new Actions.ClearTile(frameNeighbors: true), new Actions.PlaceWall(item.Wall)));
		}
		foreach (Tuple<Point, Point> item18 in list4)
		{
			Point item10 = item18.Item1;
			Point item11 = item18.Item2;
			int num2 = ((item11.X > item10.X) ? 1 : (-1));
			ShapeData shapeData = new ShapeData();
			for (int m = 0; m < item11.Y - item10.Y; m++)
			{
				shapeData.Add(num2 * (m + 1), m);
			}
			WorldUtils.Gen(item10, new ModShapes.All(shapeData), Actions.Chain(new Actions.PlaceTile((ushort)ModContent.TileType<RhyolitePlatform>(), item.PlatformStyle), new Actions.SetSlope((num2 == 1) ? 1 : 2), new Actions.SetFrames(frameNeighbors: true)));
			WorldUtils.Gen(new Point(item10.X + ((num2 == 1) ? 1 : (-4)), item10.Y - 1), new Shapes.Rectangle(4, 1), Actions.Chain(new Actions.Clear(), new Actions.PlaceWall(item.Wall), new Actions.PlaceTile((ushort)ModContent.TileType<RhyolitePlatform>(), item.PlatformStyle), new Actions.SetFrames(frameNeighbors: true)));
		}
		foreach (Point item2 in list3)
		{
			WorldUtils.Gen(item2, new Shapes.Rectangle(1, 3), new Actions.ClearTile(frameNeighbors: true));
			WorldGen.PlaceTile(item2.X, item2.Y, ModContent.TileType<RhyoliteDoorClosed>(), true, true, -1, 0);
			//Generation.Utils.SquareTileFrameArea(item2.X, item2.Y, 2);
		}
		foreach (Point item19 in list5)
		{
			WorldUtils.Gen(item19, new Shapes.Rectangle(3, 1), Actions.Chain(new Actions.ClearMetadata(), new Actions.PlaceTile((ushort)ModContent.TileType<RhyolitePlatform>(), item.PlatformStyle), new Actions.SetFrames(frameNeighbors: true)));
		}
		foreach (Rectangle item3 in list2)
		{
			if (item3.Height > 1 && _tiles[item3.X, item3.Y - 1].TileType != (ushort)ModContent.TileType<RhyolitePlatform>())
			{
				WorldUtils.Gen(new Point(item3.X, item3.Y), new Shapes.Rectangle(item3.Width, item3.Height), Actions.Chain(new Actions.SetTile((ushort)ModContent.TileType<Tiles.RhyoliteColumn>()), new Actions.SetFrames(frameNeighbors: true)));
				Tile tile = _tiles[item3.X, item3.Y + item3.Height];
				tile.Slope = SlopeType.Solid;
				tile.IsHalfBlock = false;
			}
		}
		//Point[] choices = new Point[7]
		//{
		//new Point(469, item.TableStyle),
		//new Point(16, 0),
		//new Point(18, item.WorkbenchStyle),
		//new Point(86, 0),
		//new Point(87, item.PianoStyle),
		//new Point(94, 0),
		//new Point(101, item.BookcaseStyle)
		//};
		
		Point[] choices = new Point[7]
		{
		new Point(ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteTable>(), 0),
		new Point(16, 0),
		new Point(ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteWorkBench>(), 0),
		new Point(86, 0),
		new Point(ModContent.TileType<Tiles.Furniture.Rhyolite.RhyolitePiano>(), 0),
		new Point(94, 0),
		new Point(ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteBookcase>(), 0)
		};
		 
		foreach (Rectangle item4 in list)
		{
			int num3 = item4.Width / 8;
			int num4 = item4.Width / (num3 + 1);
			int num5 = GenBase._random.Next(2);
			for (int n = 0; n < num3; n++)
			{
				int num6 = (n + 1) * num4 + item4.X;
				switch (n + num5 % 2)
				{
					case 0:
						{
							//int num7 = item4.Y + Math.Min(item4.Height / 2, item4.Height - 5);
							//Vector2 vector = WorldGen.RandHousePicture();
							//int type = (int)vector.X;
							//int style = (int)vector.Y;
							//if (!WorldGen.nearPicture(num6, num7))
							//{
							//    WorldGen.PlaceTile(num6, num7, type, mute: true, forced: false, -1, style);
							//}
							break;
						}
					case 1:
						{
							int num8 = item4.Y + 1;
							WorldGen.PlaceTile(num6, num8, ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteChandelier>(), mute: true, forced: false, -1, 0);
							for (int num9 = -1; num9 < 2; num9++)
							{
								for (int num10 = 0; num10 < 3; num10++)
								{
									GenBase._tiles[num9 + num6, num10 + num8].TileFrameX += 54;
								}
							}
							break;
						}
				}
			}
			for (int num11 = item4.Width / 8 + 3; num11 > 0; num11--)
			{
				int num12 = GenBase._random.Next(item4.Width - 3) + 1 + item4.X;
				int num14 = item4.Y + item4.Height - 2;
				switch (GenBase._random.Next(4))
				{
					case 0:
						//WorldGen.PlaceSmallPile(num12, num14, GenBase._random.Next(31, 34), 1, (ushort)ModContent.TileType<Tiles.CrystalMines.CrystalBits>()); // PlaceTile(num12, num14, TileID.Crystals);
						break;
					case 1:
						//WorldGen.PlaceTile(num12, num14, ModContent.TileType<Tiles.CrystalMines.GiantCrystalShard>(), true, false, -1, _random.Next(3));
						break;
					case 2:
						{
							//int num15 = GenBase._random.Next(2, WorldGen.statueList.Length);
							//WorldGen.PlaceTile(num12, num14, WorldGen.statueList[num15].X, mute: true, forced: false, -1, WorldGen.statueList[num15].Y);
							//if (WorldGen.StatuesWithTraps.Contains(num15))
							//{
							//    WorldGen.PlaceStatueTrap(num12, num14);
							//}
							break;
						}
					case 3:
						{
							Point point = Terraria.Utils.SelectRandom(GenBase._random, choices);
							WorldGen.PlaceTile(num12, num14, point.X, mute: true, forced: false, -1, point.Y);
							break;
						}
				}
			}
		}
		foreach (Rectangle item5 in list)
		{
			item.ProcessRoom(item5);
		}
		bool flag2 = false;
		foreach (Rectangle item6 in list)
		{
			int num16 = item6.Height - 1 + item6.Y;
			int style2 = ((num16 > (int)Main.worldSurface) ? item.ChestStyle : 0);
			for (int num17 = 0; num17 < 10; num17++)
			{
				if (flag2 = WorldGen.AddBuriedChest(GenBase._random.Next(2, item6.Width - 2) + item6.X, num16, 0, notNearOtherChests: false, 0, chestTileType: (ushort)ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteChest>()))
				{
					break;
				}
			}
			if (flag2)
			{
				break;
			}
			for (int num18 = item6.X + 2; num18 <= item6.X + item6.Width - 2; num18++)
			{
				if (flag2 = WorldGen.AddBuriedChest(num18, num16, 0, notNearOtherChests: false, 0, chestTileType: (ushort)ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteChest>()))
				{
					break;
				}
			}
			if (flag2)
			{
				break;
			}
		}
		if (!flag2)
		{
			foreach (Rectangle item7 in list)
			{
				int num19 = item7.Y - 1;
				int style3 = ((num19 > (int)Main.worldSurface) ? item.ChestStyle : 0);
				for (int num20 = 0; num20 < 10; num20++)
				{
					if (flag2 = WorldGen.AddBuriedChest(GenBase._random.Next(2, item7.Width - 2) + item7.X, num19, 0, notNearOtherChests: false, style3, chestTileType: 21))
					{
						break;
					}
				}
				if (flag2)
				{
					break;
				}
				for (int num21 = item7.X + 2; num21 <= item7.X + item7.Width - 2; num21++)
				{
					if (flag2 = WorldGen.AddBuriedChest(num21, num19, 0, notNearOtherChests: false, style3, chestTileType: 21))
					{
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
		}
		if (!flag2)
		{
			for (int num22 = 0; num22 < 1000; num22++)
			{
				int i2 = GenBase._random.Next(list[0].X - 30, list[0].X + 30);
				int num23 = GenBase._random.Next(list[0].Y - 30, list[0].Y + 30);
				int style4 = ((num23 > (int)Main.worldSurface) ? item.ChestStyle : 0);
				if (flag2 = WorldGen.AddBuriedChest(i2, num23, 0, notNearOtherChests: false, style4, chestTileType: (ushort)ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteChest>()))
				{
					break;
				}
			}
		}
		return true;
	}

	public static void AgeDefaultRoom(Rectangle room)
	{
		for (int i = 0; i < room.Width * room.Height / 16; i++)
		{
			int x = GenBase._random.Next(1, room.Width - 1) + room.X;
			int y = GenBase._random.Next(1, room.Height - 1) + room.Y;
			WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(2, 2), Actions.Chain(new Modifiers.Dither(), new Modifiers.Blotches(2, 2.0), new Modifiers.IsEmpty(), new Actions.SetTile(51, setSelfFrames: true)));
		}
		WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new Modifiers.Dither(0.85000002384185791), new Modifiers.Blotches(), new Modifiers.OnlyWalls(BuildData.Default.Wall), ((double)room.Y > Main.worldSurface) ? ((GenAction)new Actions.ClearWall(frameNeighbors: true)) : ((GenAction)new Actions.PlaceWall(2))));
		WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new Modifiers.Dither(0.949999988079071), new Modifiers.OnlyTiles(30, 321, 158), new Actions.ClearTile(frameNeighbors: true)));
	}

	public static void AgeRoom(Rectangle room)
	{
		WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new Modifiers.Dither(0.60000002384185791), new Modifiers.Blotches(2, 0.60000002384185791), new Modifiers.OnlyTiles(BuildData.Rhyolite.Tile), new Actions.SetTile((ushort)ModContent.TileType<Tiles.Rhyolite>(), setSelfFrames: true), new Modifiers.Dither(0.8), new Actions.SetTile((ushort)ModContent.TileType<Tiles.SmoothRhyolite>(), setSelfFrames: true)));
		WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new Modifiers.Dither(), new Modifiers.OnlyTiles(161), new Modifiers.Offset(0, 1), new ActionStalagtite()));
		WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new Modifiers.Dither(), new Modifiers.OnlyTiles(161), new Modifiers.Offset(0, 1), new ActionStalagtite()));
		WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new Modifiers.Dither(0.85000002384185791), new Modifiers.Blotches(2, 0.8), ((double)room.Y > Main.worldSurface) ? ((GenAction)new Actions.ClearWall(frameNeighbors: true)) : ((GenAction)new Actions.PlaceWall(0))));
	}
}

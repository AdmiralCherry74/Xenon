using System.Collections.Generic;
using Terraria.IO;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Reflection;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Common;

namespace Xenon.Content.WorldGeneration;

public class MountainGen : ModSystem
{
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	{
		GenPass currentPass;
		int index = tasks.FindIndex(genPass => genPass.Name == "Beaches");
		if (index != -1)
		{
			tasks.RemoveAt(index);
			currentPass = new OtherSideOceanPass_Beaches();
			tasks.Insert(index, currentPass);
			totalWeight += currentPass.Weight;
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Gems");
		if (index != -1)
		{
			tasks.Insert(index + 1, new MountainsGenPass());
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Ocean Sand");
		if (index != -1)
		{
			tasks[index] = new OtherSideOceanPass_OceanSand();
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Remove Broken Traps");
		if (index != -1)
		{
			currentPass = new MountainStalac();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;

			currentPass = new MountainChests();
			tasks.Insert(index + 2, currentPass);
			totalWeight += currentPass.Weight;
		}
		//1.1.CorruptBiome.2035325171
	}
}
public class MountainChests : GenPass
{
	public MountainChests() : base("Mountain Chests", 20f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		if (GenVars.dungeonSide == -1)
		{
			for (int x = 0; x < 350; x++)
			{
				for (int y = 0; y < Main.worldSurface; y++)
				{
					if (Main.tile[x, y].HasTile && Main.tile[x, y].TileType == ModContent.TileType<OuranoStone>() &&
						Main.tile[x + 1, y].HasTile && Main.tile[x + 1, y].TileType == ModContent.TileType<OuranoStone>() &&
						!Main.tile[x, y - 1].HasTile && !Main.tile[x + 1, y - 1].HasTile)
					{
						if (WorldGen.genRand.NextBool(15))
							WorldGen.AddBuriedChest(x, y - 2, Utils.GetNextCliffsideChestItem());
					}
				}
			}
		}
		else if (GenVars.dungeonSide == 1)
		{
			for (int x = Main.maxTilesX - 350; x < Main.maxTilesX; x++)
			{
				for (int y = 0; y < Main.worldSurface; y++)
				{
					if (Main.tile[x, y].HasTile && Main.tile[x, y].TileType == ModContent.TileType<OuranoStone>() &&
						Main.tile[x - 1, y].HasTile && Main.tile[x - 1, y].TileType == ModContent.TileType<OuranoStone>() &&
						!Main.tile[x, y - 1].HasTile && !Main.tile[x + 1, y - 1].HasTile)
					{
						if (WorldGen.genRand.NextBool(15))
							WorldGen.AddBuriedChest(x, y - 2, Utils.GetNextCliffsideChestItem());
					}
				}
			}
		}
	}
}

public class MountainStalac : GenPass
{
	public MountainStalac() : base("Mountain Stalac", 20f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		for (int num19 = 20; num19 < Main.maxTilesX - 20; num19++)
		{
			for (int num22 = 5; num22 < Main.maxTilesY - 20; num22++)
			{
				// mountain stalac
				if (Main.tile[num19, num22 + 1].TileType == ModContent.TileType<OuranoStone>() && Main.tile[num19, num22 + 1].HasTile && WorldGen.genRand.NextBool(3))
				{
					if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 - 1].HasTile && Main.tile[num19, num22 + 1].Slope == SlopeType.Solid)
					{
						Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<OuranoStalac>());
					}
				}
			}
		}
	}
}
public class OtherSideOceanPass_Beaches : GenPass
{
	public OtherSideOceanPass_Beaches() : base("Other Side Beaches", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		// ocean water
		int number = 50;
		progress.Message = Lang.gen[22].Value;
		bool floridaStyle = false;
		bool floridaStyle2 = false;
		if (WorldGen.genRand.Next(4) == 0)
		{
			if (WorldGen.genRand.Next(2) == 0)
			{
				floridaStyle = true;
			}
			else
			{
				floridaStyle2 = true;
			}
		}
		int leftSide = 0;
		int rightSide = 0;
		int num4;
		if (GenVars.dungeonSide == -1)
		{
			leftSide = Main.maxTilesX - WorldGen.genRand.Next(GenVars.oceanWaterStartRandomMin, GenVars.oceanWaterStartRandomMax);
			rightSide = Main.maxTilesX;
			num4 = GenVars.rightBeachStart + number;
		}
		else
		{
			leftSide = 0;
			rightSide = WorldGen.genRand.Next(GenVars.oceanWaterStartRandomMin, GenVars.oceanWaterStartRandomMax);
			num4 = GenVars.leftBeachEnd - number;
		}

		if (rightSide > num4 && GenVars.dungeonSide == 1)
		{
			rightSide = num4;
		}
		if (leftSide < num4 && GenVars.dungeonSide == -1)
		{
			leftSide = num4;
		}
		int num5 = 0;
		double num6 = 1.0;
		int j;
		for (j = 0; !Main.tile[rightSide - 1, j].HasTile; j++)
		{
		}
		GenVars.shellStartYLeft = j;
		j += WorldGen.genRand.Next(1, 5);
		if (GenVars.dungeonSide == 1)
		{
			for (int num7 = rightSide - 1; num7 >= leftSide; num7--)
			{
				if (num7 > 30)
				{
					num5++;
					MethodInfo? tune = typeof(WorldGen).GetMethod("TuneOceanDepth", BindingFlags.Static | BindingFlags.NonPublic);
					num6 = (double)tune?.Invoke(null, [num5, num6, floridaStyle]);
					//num6 = WorldGen.TuneOceanDepth(num5, num6, floridaStyle);
				}
				else
				{
					num6 += 1.0;
				}
				int num8 = WorldGen.genRand.Next(15, 20);
				for (int k = 0; k < j + num6 + num8; k++)
				{
					if (k < j + num6 * 0.75 - 3.0)
					{
						Main.tile[num7, k].Active(false);
						if (k > j)
						{
							Tile tile = Main.tile[num7, k];
							tile.LiquidAmount = 255;
							tile.LiquidType = LiquidID.Water;
						}
						else if (k == j)
						{
							Main.tile[num7, k].LiquidAmount = 127;
							if (GenVars.shellStartXLeft == 0)
							{
								GenVars.shellStartXLeft = num7;
							}
							GenVars.shellStartXRight = 500;
						}
					}
					else if (k > j)
					{
						Main.tile[num7, k].TileType = TileID.Sand;
						Main.tile[num7, k].Active(true);
					}
					Main.tile[num7, k].WallType = WallID.None;
				}
			}
		}
		else
		{
			for (int m = leftSide; m < rightSide; m++)
			{
				if (m < rightSide - 30)
				{
					num5++;
					MethodInfo? tune = typeof(WorldGen).GetMethod("TuneOceanDepth", BindingFlags.Static | BindingFlags.NonPublic);
					num6 = (double)tune?.Invoke(null, [num5, num6, floridaStyle]);
					//num10 = WorldGen.TuneOceanDepth(num11, num10, floridaStyle2);
				}
				else
				{
					num6 += 1.0;
				}
				int num12 = WorldGen.genRand.Next(15, 20);
				for (int n = 0; n < j + num6 + num12; n++)
				{
					if (n < j + num6 * 0.75 - 3.0)
					{
						Main.tile[m, n].Active(false);
						if (n > j)
						{
							Tile tile = Main.tile[m, n];
							tile.LiquidAmount = 255;
							tile.LiquidType = LiquidID.Water;
						}
						else if (n == j)
						{
							Main.tile[m, n].LiquidAmount = 127;
							if (GenVars.shellStartXRight == 0)
							{
								GenVars.shellStartXRight = m;
							}
							GenVars.shellStartXLeft = 500;
						}
					}
					else if (n > j)
					{
						Main.tile[m, n].TileType = TileID.Sand;
						Main.tile[m, n].Active(true);
					}
					Main.tile[m, n].WallType = WallID.None;
				}
			}
		}
	}
}
public class OtherSideOceanPass_OceanSand : GenPass
{
	public OtherSideOceanPass_OceanSand() : base("Other Side Ocean Sand", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("WorldGeneration.OceanSand");
		for (int i = 0; i < 1; i++)
		{
			//progress.Set(i / 3.0);
			int num = WorldGen.genRand.Next(Main.maxTilesX);
			while (num > Main.maxTilesX * 0.4 && num < Main.maxTilesX * 0.6)
			{
				num = WorldGen.genRand.Next(Main.maxTilesX);
			}
			int num2 = WorldGen.genRand.Next(35, 90);
			if (i == 1)
			{
				double num3 = Main.maxTilesX / 4200.0;
				num2 += (int)(WorldGen.genRand.Next(20, 40) * num3);
			}
			if (WorldGen.genRand.Next(3) == 0)
			{
				num2 *= 2;
			}
			if (i == 1)
			{
				num2 *= 2;
			}
			int leftSide = num - num2;
			num2 = WorldGen.genRand.Next(35, 90);
			if (WorldGen.genRand.Next(3) == 0)
			{
				num2 *= 2;
			}
			if (i == 1)
			{
				num2 *= 2;
			}
			int rightSide = num + num2;
			
			if (GenVars.dungeonSide == -1)
			{
				leftSide = GenVars.rightBeachStart;
				rightSide = Main.maxTilesX - 1;
			}
			else
			{
				leftSide = 0;
				rightSide = GenVars.leftBeachEnd;
			}
			if (leftSide < 0)
			{
				leftSide = 0;
			}
			if (leftSide > Main.maxTilesX)
			{
				leftSide = Main.maxTilesX - 1;
			}
			if (rightSide > Main.maxTilesX)
			{
				rightSide = Main.maxTilesX - 1;
			}
			if (rightSide < 0)
			{
				rightSide = 0;
			}
			//if (i == 0)
			//{

			//}
			//else if (i == 2)
			//{

			//}
			//else if (i == 1)
			//{
			//	continue;
			//}
			int num6 = WorldGen.genRand.Next(50, 100);
			for (int j = leftSide; j < rightSide; j++)
			{
				if (WorldGen.genRand.Next(2) == 0)
				{
					num6 += WorldGen.genRand.Next(-1, 2);
					if (num6 < 50)
					{
						num6 = 50;
					}
					if (num6 > 200)
					{
						num6 = 200;
					}
				}
				for (int k = 0; k < (Main.worldSurface + Main.rockLayer) / 2.0; k++)
				{
					if (WorldGen.InWorld(j, k) && Main.tile[j, k].HasTile)
					{
						if (j == (leftSide + rightSide) / 2 && WorldGen.genRand.Next(6) == 0)
						{
							GenVars.PyrX[GenVars.numPyr] = j;
							GenVars.PyrY[GenVars.numPyr] = k;
							GenVars.numPyr++;
						}
						int num7 = num6;
						if (j - leftSide < num7)
						{
							num7 = j - leftSide;
						}
						if (rightSide - j < num7)
						{
							num7 = rightSide - j;
						}
						num7 += WorldGen.genRand.Next(5);
						for (int l = k; l < k + num7; l++)
						{
							if (j > leftSide + WorldGen.genRand.Next(5) && j < rightSide - WorldGen.genRand.Next(5))
							{
								if (WorldGen.InWorld(j, l))
								{
									Main.tile[j, l].TileType = TileID.Sand;
								}
							}
						}
						break;
					}
				}
			}
		}
	}
}
public class MountainsGenPass : GenPass
{
	public MountainsGenPass() : base("Mountains", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Mountains");
		int mountainsPerSide = 3;

		int baseHeight = 35;
		int baseWidth = 80;

		if (GenVars.dungeonSide == -1)
		{
			// LEFT EDGE
			for (int i = 0; i < mountainsPerSide; i++)
			{
				int centerX = 60 + i * 140;
				GenerateMountain(centerX, baseHeight + i * 20, baseWidth + i * 35);
			}
		}
		else
		{
			// RIGHT EDGE
			for (int i = 0; i < mountainsPerSide; i++)
			{
				int centerX = Main.maxTilesX - 60 - i * 140;
				GenerateMountain(centerX, baseHeight + i * 20, baseWidth + i * 35);
			}
		}
		for (int q = 20; q < Main.maxTilesX - 20; q++)
		{
			for (int z = 100; z < Main.maxTilesY / 2; z++)
			{
				Tile tile = Main.tile[q, z];
				// snowy stone logic
				int grassLine = (int)(Main.worldSurface - 140);
				if (tile.TileType == ModContent.TileType<OuranoStone>())
				{
					if (z < grassLine)
					{
						if ((WorldGen.InWorld(q, z - 1) && tile.HasTile && !Main.tile[q, z - 1].HasTile) ||
							(WorldGen.InWorld(q, z + 1) && tile.HasTile && !Main.tile[q, z + 1].HasTile) ||
							(WorldGen.InWorld(q - 1, z) && tile.HasTile && !Main.tile[q - 1, z].HasTile) ||
							(WorldGen.InWorld(q + 1, z) && tile.HasTile && !Main.tile[q + 1, z].HasTile) ||
							(WorldGen.InWorld(q - 1, z + 1) && tile.HasTile && !Main.tile[q - 1, z - 1].HasTile) ||
							(WorldGen.InWorld(q + 1, z - 1) && tile.HasTile && !Main.tile[q - 1, z + 1].HasTile) ||
							(WorldGen.InWorld(q + 1, z - 1) && tile.HasTile && !Main.tile[q + 1, z - 1].HasTile) ||
							(WorldGen.InWorld(q + 1, z + 1) && tile.HasTile && !Main.tile[q + 1, z + 1].HasTile))
						{
							tile.TileType = (ushort)ModContent.TileType<MossyOuranoStone>();
						}
					}
					if ((WorldGen.InWorld(q, z - 1) && tile.HasTile && !Main.tile[q, z - 1].HasTile) ||
						(WorldGen.InWorld(q, z + 1) && tile.HasTile && !Main.tile[q, z + 1].HasTile) ||
						(WorldGen.InWorld(q - 1, z) && tile.HasTile && !Main.tile[q - 1, z].HasTile) ||
						(WorldGen.InWorld(q + 1, z) && tile.HasTile && !Main.tile[q + 1, z].HasTile) ||
						(WorldGen.InWorld(q - 1, z + 1) && tile.HasTile && !Main.tile[q - 1, z - 1].HasTile) ||
						(WorldGen.InWorld(q + 1, z - 1) && tile.HasTile && !Main.tile[q - 1, z + 1].HasTile) ||
						(WorldGen.InWorld(q + 1, z - 1) && tile.HasTile && !Main.tile[q + 1, z - 1].HasTile) ||
						(WorldGen.InWorld(q + 1, z + 1) && tile.HasTile && !Main.tile[q + 1, z + 1].HasTile))
					{
						WorldGen.GrowTree(q, z - 1);
					}
				}
			}
		}
	}

	private void GenerateMountain(int centerX, int height, int width)
	{
		for (int x = -width; x <= width; x++)
		{
			int worldX = centerX + x;
			if (worldX <= 20 || worldX >= Main.maxTilesX - 20) continue;

			float dist = Math.Abs(x) / (float)width;
			float baseCurve = 1f - dist * dist;
			float erosionCurve = MathHelper.Lerp(baseCurve, (float)Math.Sqrt(baseCurve), 0.6f);
			float noise = (float)(Math.Sin(worldX * 0.035f) * 0.6f + Math.Sin(worldX * 0.09f) * 0.25f);

			float heightFactor = erosionCurve + noise * 0.18f;
			if (heightFactor <= 0f)
				continue;

			int peakHeight = (int)(height * heightFactor);
			int surfaceY = Utils.TileCheck(worldX) + 5;

			for (int y = surfaceY; y > surfaceY - peakHeight; y--)
			{
				if (y < 20) break;
				if (!WorldGen.InWorld(worldX, y, 5)) continue;
				if (Main.tileSolid[Main.tile[worldX, y].TileType] && Main.tile[worldX, y].HasTile)
					continue;

				float depthFactor = (surfaceY - y) / (float)peakHeight;
				if (WorldGen.InWorld(worldX, y, 5))
				{
					Tile tile = Main.tile[worldX, y];
					tile.HasTile = true;

					// blending
					if (depthFactor < 0.35f) tile.TileType = TileID.Dirt;
					else tile.TileType = (ushort)ModContent.TileType<OuranoStone>();
				}
			}
		}
	}
}
public class ShellPileHook : ModHook
{
	protected override void Apply()
	{
		On_WorldGen.ShellPile += On_WorldGen_ShellPile;
	}

	private bool On_WorldGen_ShellPile(On_WorldGen.orig_ShellPile orig, int X, int Y)
	{
		if (X < Main.maxTilesX / 2 && GenVars.dungeonSide == -1) return false;
		if (X > Main.maxTilesX / 2 && GenVars.dungeonSide == 1) return false;
		return orig.Invoke(X, Y);
	}
}

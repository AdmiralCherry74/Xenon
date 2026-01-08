using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Common;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.Natural.Snow;
using Xenon.Hooks;

namespace Xenon.Content.WorldGeneration;

internal class IceModifications : ModSystem
{
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	{
		GenPass currentPass;
		int index = tasks.FindIndex(genPass => genPass.Name == "Generate Ice Biome");
		if (index != -1)
		{
			currentPass = new IceModGenPass();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Remove Broken Traps");
		if (index != -1)
		{
			currentPass = new LavaStalac();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
	}
}
public class IceModGenPass : GenPass
{
	public IceModGenPass() : base("Frozen Lava", 10f)
	{
	}
	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Ice");
		GenVars.snowTop = (int)Main.worldSurface;
		int lavaLine = GenVars.lavaLine + WorldGen.genRand.Next(75, 100);
		//if (WorldGen.remixWorldGen)
		//{
		//	lavaLine = Main.maxTilesY - 250;
		//	lavaLineMod = lavaLine - WorldGen.genRand.Next(160, 200);
		//}

		int snowLeft = GenVars.snowMinX[GenVars.snowBottom];
		int snowRight = GenVars.snowMaxX[GenVars.snowBottom];
		int num979 = 10;
		for (int ypos = GenVars.snowBottom; ypos <= lavaLine; ypos++)
		{
			progress.Set((double)ypos / (lavaLine));
			snowLeft += WorldGen.genRand.Next(-4, 4);
			snowRight += WorldGen.genRand.Next(-3, 5);
			if (ypos > 0)
			{
				snowLeft = (snowLeft + GenVars.snowMinX[ypos - 1]) / 2;
				snowRight = (snowRight + GenVars.snowMaxX[ypos - 1]) / 2;
			}

			if (GenVars.dungeonSide > 0)
			{
				if (WorldGen.genRand.NextBool(4))
				{
					snowLeft++;
					snowRight++;
				}
			}
			else if (WorldGen.genRand.NextBool(4))
			{
				snowLeft--;
				snowRight--;
			}

			GenVars.snowMinX[ypos] = snowLeft;
			GenVars.snowMaxX[ypos] = snowRight;
			for (int xpos = snowLeft; xpos < snowRight; xpos++)
			{
				if (ypos < lavaLine)
				{
					if (Main.tile[xpos, ypos].WallType == 2)
						Main.tile[xpos, ypos].WallType = 40;

					switch (Main.tile[xpos, ypos].TileType)
					{
						case 0:
						case 2:
						case 23:
						case 40:
						case 53:
							Main.tile[xpos, ypos].TileType = 147;
							break;
						case 1:
							Main.tile[xpos, ypos].TileType = 161;
							break;
					}
					if (WorldGen.genRand.NextBool(60))
					{
						WorldGen.OreRunner(xpos, ypos, 7, 7, (ushort)ModContent.TileType<FrozenLava>());
					}
				}
				else
				{
					num979 += WorldGen.genRand.Next(-3, 4);
					if (WorldGen.genRand.NextBool(3))
					{
						num979 += WorldGen.genRand.Next(-4, 5);
						if (WorldGen.genRand.NextBool(3))
							num979 += WorldGen.genRand.Next(-6, 7);
					}

					if (num979 < 0)
						num979 = WorldGen.genRand.Next(3);
					else if (num979 > 50)
						num979 = 50 - WorldGen.genRand.Next(3);

					for (int num982 = ypos; num982 < ypos + num979; num982++)
					{
						if (Main.tile[xpos, num982].WallType == 2)
							Main.tile[xpos, num982].WallType = 40;

						switch (Main.tile[xpos, num982].TileType)
						{
							case 0:
							case 2:
							case 23:
							case 40:
							case 53:
								Main.tile[xpos, num982].TileType = 147;
								break;
							case 1:
								Main.tile[xpos, num982].TileType = 161;
								break;
						}
						if (WorldGen.genRand.NextBool(60))
						{
							WorldGen.OreRunner(xpos, ypos, 7, 7, (ushort)ModContent.TileType<FrozenLava>());
						}
					}
				}
			}

			if (GenVars.snowBottom < ypos)
				GenVars.snowBottom = ypos;
		}
	}
}
public class IceChestHook : ModHook
{
	protected override void Apply()
	{
		IL_WorldGen.AddBuriedChest_int_int_int_bool_int_bool_ushort += IL_WorldGen_AddBuriedChest_int_int_int_bool_int_bool_ushort;
	}

	private void IL_WorldGen_AddBuriedChest_int_int_int_bool_int_bool_ushort(MonoMod.Cil.ILContext il)
	{
		HookUtilities.AddAlternativeIdChecks(il, TileID.IceBlock, id => Common.Data.TileSets.Ice.Contains(id));
	}
}

public class LavaStalac : GenPass
{
	public LavaStalac() : base("Frozen Lava Stalac", 20f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		for (int num19 = 20; num19 < Main.maxTilesX - 20; num19++)
		{
			for (int num22 = 5; num22 < Main.maxTilesY - 20; num22++)
			{
				// rhyolite stalac
				if (Main.tile[num19, num22 - 1].TileType == ModContent.TileType<FrozenLava>() && Main.tile[num19, num22 - 1].HasTile && WorldGen.genRand.NextBool(3))
				{
					if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 + 1].HasTile && Main.tile[num19, num22 - 1].Slope == SlopeType.Solid)
					{
						Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<FrozenLavaStalac>());
					}
				}
			}
		}
	}
}

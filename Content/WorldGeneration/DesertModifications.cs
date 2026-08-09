using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Natural.OceanAndTheMarine;

namespace Xenon.Content.WorldGeneration;

internal class DesertModifications : ModSystem
{
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	{
		GenPass currentPass;
		int index = tasks.FindIndex(genPass => genPass.Name == "Full Desert");
		if (index != -1)
		{
			currentPass = new QuicksandPass();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Create Ocean Caves");
		if (index != -1)
		{
			currentPass = new MirageThingOhLookItsTotallyAnOriginalBiomeIdeaLetsJustStealAVanillaBiomeAndReplaceItEntirelyAndGenerateTheBiomeOverTheUndergroundDesertOMQWhyIsThisAThingNowIDontLikeThisIdeaWhy();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
		index = tasks.FindIndex(genPass => genPass.Name == "Spreading Grass");
		if (index != -1)
		{
			currentPass = new QuickmudPass();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;

			currentPass = new PowderedSnowPass();
			tasks.Insert(index + 1, currentPass);
			totalWeight += currentPass.Weight;
		}
	}
}
internal class QuicksandPass : GenPass
{
	public QuicksandPass() : base("Quicksand", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Quicksand");
		for (int i = 150; i < Main.maxTilesX - 150; i++)
		{
			for (int j = (int)Main.worldSurface;  j < Main.maxTilesY - 250; j++)
			{
				if (Main.tile[i, j].TileType == TileID.Sandstone && WorldGen.genRand.NextBool(20) && !Main.tileSolid[Main.tile[i, j - 1].TileType])
				{
					WorldGen.OreRunner(i, j, 9, 12, (ushort)ModContent.TileType<Quicksand>());
				}
			}
		}
	}
}
internal class QuickmudPass : GenPass
{
	public QuickmudPass() : base("Quickmud", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Quicksand");
		for (int i = 150; i < Main.maxTilesX - 150; i++)
		{
			for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 250; j++)
			{
				if (Main.tile[i, j].TileType == TileID.JungleGrass && WorldGen.genRand.NextBool(20) && !Main.tileSolid[Main.tile[i, j - 1].TileType])
				{
					WorldGen.TileRunner(i, j, 9, 12, (ushort)ModContent.TileType<Quickmud>());
				}
			}
		}
	}
}
internal class PowderedSnowPass : GenPass
{
	public PowderedSnowPass() : base("Powdered Snow", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.Quicksand");
		for (int i = 150; i < Main.maxTilesX - 150; i++)
		{
			for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 250; j++)
			{
				if ((Main.tile[i, j].TileType == TileID.IceBlock || Main.tile[i, j].TileType == TileID.SnowBlock) && WorldGen.genRand.NextBool(20) && !Main.tileSolid[Main.tile[i, j - 1].TileType])
				{
					WorldGen.TileRunner(i, j, 9, 12, (ushort)ModContent.TileType<PowderedSnow>());
				}
			}
		}
	}
}

public class MirageThingOhLookItsTotallyAnOriginalBiomeIdeaLetsJustStealAVanillaBiomeAndReplaceItEntirelyAndGenerateTheBiomeOverTheUndergroundDesertOMQWhyIsThisAThingNowIDontLikeThisIdeaWhy : GenPass
{
	public MirageThingOhLookItsTotallyAnOriginalBiomeIdeaLetsJustStealAVanillaBiomeAndReplaceItEntirelyAndGenerateTheBiomeOverTheUndergroundDesertOMQWhyIsThisAThingNowIDontLikeThisIdeaWhy() : base("Mirage", 10f)
	{
	}

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = Language.GetTextValue("Mods.Xenon.Generation.UndergroundOcean");

		int xStart = 0;
		int xEnd = 0;
		if (GenVars.dungeonSide == -1)
		{
			xStart = GenVars.rightBeachStart;
			xEnd = Main.maxTilesX - 10;
		}
		else if (GenVars.dungeonSide == 1)
		{
			xStart = 10;
			xEnd = GenVars.leftBeachEnd;
		}

		for (int x = xStart; x <= xEnd; x++)
		{
			for (int y = (int)Main.worldSurface - 40; y <= GenVars.lavaLine; y++)
			{
				if (Main.tile[x, y].LiquidAmount > 0 || !Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType]) continue;
				if ((TileID.Sets.Grass[Main.tile[x, y].TileType] || Main.tile[x, y].TileType == TileID.Dirt) && Main.tile[x, y].HasTile) continue;
				if (!Main.tile[x, y + 1].HasTile && Main.tile[x, y].TileType != TileID.Granite && Main.tile[x, y].TileType != TileID.Marble)
				{
					Main.tile[x, y].TileType = (ushort)ModContent.TileType<MarineSandstone>();
				}
				else if (TileID.Sets.CanBeClearedDuringOreRunner[Main.tile[x, y].TileType])
				{
					Main.tile[x, y].TileType = (ushort)ModContent.TileType<MarineSand>();
				}
			}
		}
		for (int x = xStart; x <= xEnd; x++)
		{
			for (int y = (int)Main.worldSurface - 40; y <= GenVars.lavaLine; y++)
			{
				if (x == xStart || x == xEnd)
				{
					if (y % 5 == 0)
					{
						WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 13), WorldGen.genRand.Next(11, 14), ModContent.TileType<HardenedMarineSand>(), ignoreTileType: TileID.Grass);
					}
				}
				if (y == GenVars.lavaLine)
				{
					if (x % 5 == 0)
					{
						WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 13), WorldGen.genRand.Next(11, 14), ModContent.TileType<HardenedMarineSand>(), ignoreTileType: TileID.Grass);
					}
				}
			}
		}
	}
}
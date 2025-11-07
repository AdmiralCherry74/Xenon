using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Content.Tiles;

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
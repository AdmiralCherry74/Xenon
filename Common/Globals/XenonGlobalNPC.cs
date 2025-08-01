using System.Collections.Generic;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.NPCs;

namespace Xenon.Common.Globals;

internal class XenonGlobalNPC : GlobalNPC
{
	public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
	{
		if (spawnInfo.Player.InModBiome<Corrosion>())
		{
			pool.Clear();
			pool.Add(ModContent.NPCType<Gastritis>(), 0.5f);
			pool.Add(ModContent.NPCType<StomachBug>(), 0.5f);
			pool.Add(ModContent.NPCType<TapeWormHead>(), 0.5f);

			//if (Main.hardMode)
			//{
			//	pool.Add(ModContent.NPCType<PLACEHOLDER_1>(), 0.8f);
			//	pool.Add(ModContent.NPCType<PLACEHOLDER_2>(), 0.7f);
			//	if (spawnInfo.Player.ZoneRockLayerHeight)
			//	{
			//		pool.Add(ModContent.NPCType<PLACEHOLDER_3>(), 1f);
			//	}

			//	if (spawnInfo.Player.ZoneDesert)
			//	{
			//		pool.Add(ModContent.NPCType<PLACEHOLDER_4>(), 0.3f);
			//		pool.Add(ModContent.NPCType<PLACEHOLDER_5>(), 1f);
			//	}
			//}
		}
	}
}

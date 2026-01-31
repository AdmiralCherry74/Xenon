using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.NPCs.CorrosionMobs;
using Xenon.Content.NPCs.CorruptionMobs;
using Xenon.Content.NPCs.CrimsonMobs;
using Xenon.Content.NPCs.JungleMobs;
using Xenon.Content.NPCs.MountainsMobs;
using Xenon.Content.NPCs.UndergroundMobs;

namespace Xenon.Common.Globals;

internal class XenonGlobalNPC : GlobalNPC
{
	public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
	{
		if (spawnInfo.Player.InModBiome<Mountain>())
		{
			pool.Clear();
			pool.Add(ModContent.NPCType<Sparrow>(), 0.4f);
			pool.Add(ModContent.NPCType<JebelSlime>(), 0.4f);
			pool.Add(ModContent.NPCType<Chipmunk>(), 0.4f);
		}
		if (spawnInfo.Player.InModBiome<CorrosionDesert>())
		{
			pool.Clear();
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<Aslugic>(), 0.75f);
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CorrodedCultist>(), 0.25f);
            }
            if (NPC.downedBoss2)
            {
                pool.Add(ModContent.NPCType<TapeWormHead>(), 0.50f);
                pool.Add(ModContent.NPCType<StomachBug>(), 0.50f);
                pool.Add(ModContent.NPCType<HalfDigested>(), 0.75f);
            }
		}
        if (spawnInfo.Player.InModBiome<CorrosionJungle>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
			pool.Add(ModContent.NPCType<Aslugic>(), 0.75f);
			pool.Add(ModContent.NPCType<CorrodedHornet>(), 1.5f);
            pool.Add(ModContent.NPCType<CorrodedHornet>(), 0.5f);
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CorrodedCultist>(), 0.25f);
            }
            if (NPC.downedBoss2)
            {
                pool.Add(ModContent.NPCType<TapeWormHead>(), 0.50f);
                pool.Add(ModContent.NPCType<StomachBug>(), 0.50f);
                pool.Add(ModContent.NPCType<HalfDigested>(), 0.75f);
            }
        }
        if (spawnInfo.Player.InModBiome<Corrosion>())
		{
			pool.Clear();
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<Aslugic>(), 0.75f);
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CorrodedCultist>(), 0.25f);
            }
            if (NPC.downedBoss2)
			{
                pool.Add(ModContent.NPCType<TapeWormHead>(), 0.50f);
                pool.Add(ModContent.NPCType<StomachBug>(), 0.50f);
                pool.Add(ModContent.NPCType<HalfDigested>(), 0.75f);
            }
        }
        if (spawnInfo.Player.InModBiome<CrimsonJungle>())
        {
            pool.Add(ModContent.NPCType<CrimfiedHornet>(), 1.5f);
            pool.Add(ModContent.NPCType<NeuroticManEater>(), 0.5f);
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CrimsonCultist>(), 0.25f);
            }
            if (NPC.downedBoss2)
            {
                pool.Add(ModContent.NPCType<CapillarieHead>(), 0.10f);
                pool.Add(ModContent.NPCType<Clotter>(), 0.10f);
            }
        }
        if (spawnInfo.Player.InModBiome<CorruptionJungle>())
        {
            pool.Add(ModContent.NPCType<CorruptHornet>(), 1.5f);
            pool.Add(ModContent.NPCType<SinfulManEater>(), 0.5f);
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CorruptCultist>(), 0.25f);
            }
            if (NPC.downedBoss2)
            {
                pool.Add(ModContent.NPCType<NightmareWalker>(), 0.10f);
                pool.Add(ModContent.NPCType<Evphila>(), 0.10f);
                pool.Add(ModContent.NPCType<Venial>(), 0.10f);
            }
        }
        if (spawnInfo.Player.ZoneLihzhardTemple && !NPC.downedPlantBoss)
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<TempleSentry>(), 1);
        }
        if (spawnInfo.Player.ZoneDungeon && NPC.downedBoss3) //It made no sense for all of the skeletons to not be in the dungeon. so i added them, I also added the sawblades
        {
            //Normal Skeleton
            pool.Add(NPCID.SmallSkeleton, 0.05f);
            pool.Add(NPCID.Skeleton, 0.05f);
            pool.Add(NPCID.BigSkeleton, 0.05f);
            pool.Add(NPCID.SmallHeadacheSkeleton, 0.05f);
            pool.Add(NPCID.HeadacheSkeleton, 0.05f);
            pool.Add(NPCID.BigHeadacheSkeleton, 0.05f);
            pool.Add(NPCID.SmallMisassembledSkeleton, 0.05f);
            pool.Add(NPCID.MisassembledSkeleton, 0.05f);
            pool.Add(NPCID.BigMisassembledSkeleton, 0.05f);
            pool.Add(NPCID.SmallPantlessSkeleton, 0.05f);
            pool.Add(NPCID.PantlessSkeleton, 0.05f);
            pool.Add(NPCID.BigPantlessSkeleton, 0.05f);

            if (Main.expertMode)
            {
                pool.Add(NPCID.BoneThrowingSkeleton, 0.025f);
                pool.Add(NPCID.BoneThrowingSkeleton2, 0.025f);
                pool.Add(NPCID.BoneThrowingSkeleton3, 0.025f);
            }

            //Varients
            pool.Add(NPCID.GreekSkeleton, 0.015f);
            pool.Add(NPCID.Tim, 0.005f);

            if (DateTime.Now.Month == 10)
            {
                pool.Add(NPCID.SkeletonAstonaut, 0.025f);
                pool.Add(NPCID.SkeletonTopHat, 0.025f);
                pool.Add(NPCID.SkeletonAlien, 0.025f);
            }
        }
        if (spawnInfo.Player.ZoneRockLayerHeight)
        {
            pool.Add(ModContent.NPCType<SmallSawblade>(), 0.85f);
            pool.Add(ModContent.NPCType<Sawblade>(), 0.60f);
            pool.Add(ModContent.NPCType<LargeSawblade>(), 0.35f);
        }

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
public class DamageOverTimeGlobalNPC : GlobalNPC
{
	public override bool InstancePerEntity => true;
	public bool Cleaved;

	public override void ResetEffects(NPC npc)
	{
		Cleaved = false;
	}

	public override void UpdateLifeRegen(NPC npc, ref int damage)
	{
		if (npc.HasBuff<Cleaved>())
		{
			npc.lifeRegen -= 4;
		}
	}
}
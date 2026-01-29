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
            pool.Clear();
            pool.Add(ModContent.NPCType<CrimfiedHornet>(), 1.5f);
            pool.Add(ModContent.NPCType<NeuroticManEater>(), 0.5f);
            pool.Add(NPCID.FaceMonster, 0.75f);
            pool.Add(NPCID.Crimera, 1);
            pool.Add(NPCID.LittleCrimera, 1);
            pool.Add(NPCID.BigCrimera, 1);
            pool.Add(NPCID.BloodCrawler, 0.50f);
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
            pool.Clear();
            pool.Add(ModContent.NPCType<CorruptHornet>(), 1.5f);
            pool.Add(ModContent.NPCType<SinfulManEater>(), 0.5f);
            pool.Add(NPCID.EaterofSouls, 1f);
            pool.Add(NPCID.LittleEater, 1f);
            pool.Add(NPCID.BigEater, 1f);
            pool.Add(NPCID.DevourerHead, 0.50f);
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
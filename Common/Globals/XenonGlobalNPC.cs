using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.NPCs.CatacombMobs;
using Xenon.Content.NPCs.CorrosionMobs;
using Xenon.Content.NPCs.CorruptionMobs;
using Xenon.Content.NPCs.CrimsonMobs;
using Xenon.Content.NPCs.JungleMobs;
using Xenon.Content.NPCs.MountainsMobs;
using Xenon.Content.NPCs.Other;

namespace Xenon.Common.Globals;

internal class XenonGlobalNPC : GlobalNPC
{
    public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
    {
        if (!Main.dayTime && spawnInfo.Player.ZoneOverworldHeight)
        {
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<ConeheadZombie>(), 0.5f);
            }
            if (NPC.downedBoss2)
            {
                pool.Add(ModContent.NPCType<BucketheadZombie>(), 0.5f);
            }
        }
        if (spawnInfo.Player.ZoneSkyHeight && !Main.hardMode)
        {
            pool.Remove(NPCID.Harpy);
            pool.Add(NPCID.Harpy, 0.33f);
        }
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
        if (spawnInfo.Player.InModBiome<Catacombs>())
        {
            pool.Clear();
            pool.Add(NPCID.Zombie, 1); //temporary
            pool.Add(NPCID.PincushionZombie, 1); //temporary
            pool.Add(NPCID.TorchZombie, 1); //temporary
            pool.Add(ModContent.NPCType<MoonWidowWall>(), 0.1f);
            pool.Add(ModContent.NPCType<SmallFallenSurvivor>(), 0.5f);
            pool.Add(ModContent.NPCType<FallenSurvivor>(), 0.4f);
            pool.Add(ModContent.NPCType<BigFallenSurvivor>(), 0.3f);
            pool.Add(ModContent.NPCType<Revenant>(), 0.2f);
            if (Main.expertMode)
            {
                pool.Add(NPCID.ArmedZombie, 0.5f); //temporary
                pool.Add(NPCID.ArmedZombiePincussion, 0.5f); //temporary
                pool.Add(NPCID.ArmedTorchZombie, 0.5f); //temporary
                pool.Add(ModContent.NPCType<SmallFallenSurvivorExpert>(), 0.4f);
                pool.Add(ModContent.NPCType<FallenSurvivorExpert>(), 0.3f);
                pool.Add(ModContent.NPCType<BigFallenSurvivorExpert>(), 0.2f);
            }
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
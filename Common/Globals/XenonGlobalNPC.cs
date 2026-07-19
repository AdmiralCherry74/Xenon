using Avalon.DropConditions;
using System.Collections.Generic;
using System.Security.Policy;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Biomes;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Items.Materials;
using Xenon.Content.NPCs.CatacombMobs;
using Xenon.Content.NPCs.CorrosionMobs;
using Xenon.Content.NPCs.CorruptionMobs;
using Xenon.Content.NPCs.CrimsonMobs;
using Xenon.Content.NPCs.JungleMobs;
using Xenon.Content.NPCs.MountainsMobs;
using Xenon.Content.NPCs.Other;
using Xenon.Content.NPCs.SurfacePurity;
using Xenon.Content.NPCs.UndergroundMobs;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Common.Globals;

internal class XenonGlobalNPC : GlobalNPC
{
    public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
    {
        //fuck harpy spawn rates. ts needed nerfed
        if (spawnInfo.Player.ZoneSkyHeight && !Main.hardMode)
        {
            pool.Remove(NPCID.Harpy);
            pool.Add(NPCID.Harpy, 0.33f);
        }

        if (spawnInfo.Player.ZoneLihzhardTemple && !NPC.downedPlantBoss)
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<TempleSentry>(), 1);
        }

        #region Adds enemies to existing biomes on boss deaths
        if (Main.dayTime && spawnInfo.Player.ZoneForest && !Main.hardMode)
        {
            if (NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<ChartreuseSlime>(), 1f);
                pool.Add(ModContent.NPCType<VioletSlime>(), 0.80f);
                pool.Add(ModContent.NPCType<OrangeSlime>(), 0.20f);
            }
        }
        if (!Main.dayTime && spawnInfo.Player.ZoneOverworldHeight && !Main.hardMode)
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
        if (spawnInfo.Player.ZoneNormalUnderground && !Main.hardMode)
        {
            if (!NPC.downedBoss1)
            {
                pool.Add(ModContent.NPCType<CyanSlime>(), 0.90f);
            }
        }
        #endregion

        if (spawnInfo.Player.InModBiome<Mountain>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<Sparrow>(), 0.4f);
            pool.Add(ModContent.NPCType<JebelSlime>(), 0.4f);
            pool.Add(ModContent.NPCType<Chipmunk>(), 0.4f);
        }

        #region The Mirage
        if (spawnInfo.Player.InModBiome<TheMirage>() && !spawnInfo.Player.ZoneOverworldHeight && !spawnInfo.Player.ZoneRockLayerHeight && !spawnInfo.Player.ZoneUndergroundDesert)
        {
            //If in the underground layer of The Mirage
            pool.Clear();
            pool.Add(NPCID.Scorpion, 1f);
            pool.Add(NPCID.SandSlime, 0.75f);
            pool.Add(NPCID.Tumbleweed, 0.25f);
        }
        if (spawnInfo.Player.InModBiome<TheMirage>() && !spawnInfo.Player.ZoneOverworldHeight && !spawnInfo.Player.ZoneDirtLayerHeight && !spawnInfo.Player.ZoneUndergroundDesert)
        {
            //If in the cavern layer of The Mirage
            pool.Clear();
            pool.Add(NPCID.SandSlime, 1.5f);
            pool.Add(NPCID.Antlion, 0.50f);
            pool.Add(NPCID.FlyingAntlion, 0.10f);
            pool.Add(NPCID.Tumbleweed, 0.45f);
            pool.Add(NPCID.TombCrawlerHead, 0.05f);
            #region Corrupt Mirage
            if (spawnInfo.Player.ZoneCorrupt && !spawnInfo.Player.ZoneOverworldHeight)
            {
                pool.Remove(NPCID.Antlion);
                pool.Add(NPCID.Antlion, 0.25f);
                pool.Add(NPCID.LittleEater, 0.65f);
                pool.Add(NPCID.EaterofSouls, 0.50f);
                pool.Add(NPCID.BigEater, 0.35f);
                pool.Add(NPCID.DevourerHead, 0.10f);
                pool.Remove(NPCID.FlyingAntlion);
                pool.Remove(NPCID.TombCrawlerHead);
                pool.Remove(NPCID.SandSlime);
                if (NPC.downedBoss1)
                {
                    pool.Add(ModContent.NPCType<CorruptCultist>(), 0.10f);
                }
                if (NPC.downedBoss2)
                {
                    pool.Add(ModContent.NPCType<NightmareWalker>(), 0.10f);
                    pool.Add(ModContent.NPCType<Evphila>(), 0.05f);
                }
            }
            #endregion

            #region Crimfied Mirage
            if (spawnInfo.Player.ZoneCrimson && !spawnInfo.Player.ZoneOverworldHeight)
            {
                pool.Remove(NPCID.Antlion);
                pool.Add(NPCID.Antlion, 0.25f);
                pool.Add(NPCID.LittleCrimera, 0.65f);
                pool.Add(NPCID.Crimera, 0.50f);
                pool.Add(NPCID.BigCrimera, 0.35f);
                pool.Add(NPCID.FaceMonster, 0.10f);
                pool.Add(NPCID.BloodCrawler, 0.05f);
                pool.Remove(NPCID.FlyingAntlion);
                pool.Remove(NPCID.TombCrawlerHead);
                pool.Remove(NPCID.SandSlime);
                if (NPC.downedBoss1)
                {
                    pool.Add(ModContent.NPCType<CrimsonCultist>(), 0.10f);
                }
                if (NPC.downedBoss2)
                {
                    pool.Add(ModContent.NPCType<CapillarieHead>(), 0.10f);
                }
            }
            #endregion

            #region Corroded Mirage
            if ((spawnInfo.Player.InModBiome<Corrosion>() || spawnInfo.Player.InModBiome<CorrosionUnderground>()) && !spawnInfo.Player.ZoneOverworldHeight)
            {
                pool.Remove(NPCID.Antlion);
                pool.Add(NPCID.Antlion, 0.50f);
                pool.Add(ModContent.NPCType<LittleGastritis>(), 0.65f);
                pool.Add(ModContent.NPCType<Gastritis>(), 0.50f);
                pool.Add(ModContent.NPCType<BigGastritis>(), 0.35f);
                pool.Remove(NPCID.FlyingAntlion);
                pool.Remove(NPCID.TombCrawlerHead);
                pool.Remove(NPCID.SandSlime);
                if (NPC.downedBoss1)
                {
                    pool.Add(ModContent.NPCType<CorrodedCultist>(), 0.10f);
                }
                if (NPC.downedBoss2)
                {
                    pool.Add(ModContent.NPCType<TapeWormHead>(), 0.15f);
                }
            }
            #endregion
        }
        #endregion



        #region Corrosion Biomes
        if (spawnInfo.Player.InModBiome<Corrosion>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<LittleGastritis>(), 1.25f);
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<BigGastritis>(), 0.75f);
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
        if (spawnInfo.Player.InModBiome<CorrosionDesert>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<LittleGastritis>(), 1.25f);
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<BigGastritis>(), 0.75f);
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
            pool.Add(ModContent.NPCType<LittleGastritis>(), 1.25f);
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<BigGastritis>(), 0.75f);
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
        #endregion

        #region Evil Jungles
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
        #endregion

        #region Catacombs
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
        #endregion
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
    public override void ModifyGlobalLoot(GlobalLoot globalLoot)
    {
        globalLoot.Add(ItemDropRule.ByCondition(new PuritySoulConditions(), ModContent.ItemType<SoulOfRight>(), 5, 1, 1));
    }
}

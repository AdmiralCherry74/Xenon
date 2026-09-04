using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Common.Systems;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Biomes.Catacombs;
using Xenon.Content.Biomes.Mountian;
using Xenon.Content.Biomes.Autumn;
using Xenon.Content.Biomes.UndergroundOcean;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.NPCs.CatacombMobs;
using Xenon.Content.NPCs.CavernMobs;
using Xenon.Content.NPCs.CorrosionMobs;
using Xenon.Content.NPCs.CorruptionMobs;
using Xenon.Content.NPCs.CrimsonMobs;
using Xenon.Content.NPCs.CutNPCs;
using Xenon.Content.NPCs.JungleMobs;
using Xenon.Content.NPCs.MountainsMobs;
using Xenon.Content.NPCs.OceanMobs;
using Xenon.Content.NPCs.Other;
using Xenon.Content.NPCs.SurfacePurity;
using Xenon.Content.NPCs.UndergroundMobs;
using Xenon.Content.NPCs.AutumnMobs;
using Xenon.Content.Dusts;

namespace Xenon.Common.Globals.XenonNPCGlobals;

internal class XenonGlobalNPC : GlobalNPC
{
    // Implimented
    public static int corrosionBoss = -1;           // Stomach of Cthulhu

    // To be implemented
    public static int antBossCharger = -1;          // Colony Squires Charger
    public static int antBossRanger = -1;           // Colony Squires Ranger
    public static int antBossSinger = -1;           // Colony Squires Singer
    public static int centepedeBoss = -1;           // Thornapede
    public static int furnaceBoss = -1;             // Infurnace




    public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
    {
        //fuck harpy spawn rates. ts needed nerfed
        if (!Main.hardMode && spawnInfo.Sky)
        {
            pool.Remove(NPCID.Harpy);
            pool.Add(NPCID.Harpy, 0.33f);
        }

        // Removes certain monsters for now
        pool.Remove(NPCID.GiantShelly);
        pool.Remove(NPCID.GiantShelly2);

        pool.Remove(NPCID.Salamander);
        pool.Remove(NPCID.Salamander2);
        pool.Remove(NPCID.Salamander3);
        pool.Remove(NPCID.Salamander4);
        pool.Remove(NPCID.Salamander5);
        pool.Remove(NPCID.Salamander6);
        pool.Remove(NPCID.Salamander7);
        pool.Remove(NPCID.Salamander8);
        pool.Remove(NPCID.Salamander9);

        pool.Remove(NPCID.Crawdad);
        pool.Remove(NPCID.Crawdad2);

        pool.Remove(NPCID.FireImp);
        pool.Remove(NPCID.Demon);
        pool.Remove(NPCID.VoodooDemon);
        pool.Remove(NPCID.BoneSerpentHead);

        if (spawnInfo.Player.ZoneLihzhardTemple && !NPC.downedPlantBoss)
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<TempleSentry>(), 1);
        }

        #region Enemies spawn upon Boss Deaths
        #region Dynamic
        #region Bandit and Bandit Looters
        if (Main.dayTime && spawnInfo.Player.ZoneOverworldHeight && !Main.hardMode && !(NPC.AnyNPCs(ModContent.NPCType<Bandit>()) || (NPC.AnyNPCs(ModContent.NPCType<BanditLooter>())))) //preboss
        {
            pool.Add(ModContent.NPCType<Bandit>(), 0.05f);
            if (NPC.downedBoss1)
            {
                pool.Remove(ModContent.NPCType<Bandit>());
                pool.Add(ModContent.NPCType<Bandit>(), 0.075f);
            }
            if (NPC.downedBoss2)
            {
                pool.Remove(ModContent.NPCType<Bandit>());
                pool.Add(ModContent.NPCType<Bandit>(), 0.1f);
            }
            if (NPC.downedBoss3)
            {
                pool.Remove(ModContent.NPCType<Bandit>());
                pool.Add(ModContent.NPCType<Bandit>(), 0.125f);
            }
        }
        if (spawnInfo.Player.ZoneNormalCaverns && !Main.hardMode && !(NPC.AnyNPCs(ModContent.NPCType<Bandit>()) || (NPC.AnyNPCs(ModContent.NPCType<BanditLooter>())))) //preboss
        {
            pool.Add(ModContent.NPCType<BanditLooter>(), 0.045f);
            if (NPC.downedBoss1)
            {
                pool.Remove(ModContent.NPCType<BanditLooter>());
                pool.Add(ModContent.NPCType<BanditLooter>(), 0.070f);
            }
            if (NPC.downedBoss2)
            {
                pool.Remove(ModContent.NPCType<BanditLooter>());
                pool.Add(ModContent.NPCType<BanditLooter>(), 0.95f);
            }
            if (NPC.downedBoss3)
            {
                pool.Remove(ModContent.NPCType<BanditLooter>());
                pool.Add(ModContent.NPCType<BanditLooter>(), 0.120f);
            }
        }
        #endregion
        #endregion
        if (NPC.downedSlimeKing)
        {
            if (Main.dayTime && spawnInfo.Player.ZoneForest && !Main.hardMode)
            {
                pool.Add(ModContent.NPCType<ChartreuseSlime>(), 1f);
                pool.Add(ModContent.NPCType<VioletSlime>(), 0.80f);
                pool.Add(ModContent.NPCType<OrangeSlime>(), 0.20f);
            }

            if (spawnInfo.Player.ZoneNormalUnderground && !Main.hardMode)
            {
                pool.Add(ModContent.NPCType<CyanSlime>(), 0.90f);
                pool.Add(ModContent.NPCType<IndigoSlime>(), 0.70f);
            }
        }
        if (NPC.downedBoss1)
        {
            if (!Main.dayTime && spawnInfo.Player.ZoneOverworldHeight && !Main.hardMode)
            {
            }

            if (spawnInfo.Player.ZoneRockLayerHeight && !(spawnInfo.Player.ZoneCorrupt || spawnInfo.Player.ZoneCrimson || spawnInfo.Player.InModBiome<Corrosion>() || spawnInfo.Player.ZoneSnow || spawnInfo.Player.ZoneUndergroundDesert))
            {
                pool.Add(NPCID.GiantShelly, 0.45f);
                pool.Add(NPCID.GiantShelly2, 0.45f);

                pool.Add(NPCID.Crawdad, 0.50f);
                pool.Add(NPCID.Crawdad2, 0.50f);
            }
            if (spawnInfo.Player.ZoneRockLayerHeight)
            {
                pool.Add(ModContent.NPCType<SmallSawblade>(), 0.20f);
                pool.Add(ModContent.NPCType<Sawblade>(), 0.10f);
                pool.Add(ModContent.NPCType<LargeSawblade>(), 0.5f);
            }
        }
        #region Evil Bosses
        if (NPC.downedBoss2)
        {
            if (spawnInfo.Player.ZoneRockLayerHeight && !(spawnInfo.Player.ZoneCorrupt || spawnInfo.Player.ZoneCrimson || spawnInfo.Player.InModBiome<Corrosion>() || spawnInfo.Player.ZoneSnow || spawnInfo.Player.ZoneUndergroundDesert))
            {
                pool.Add(NPCID.Salamander, 0.25f);
                pool.Add(NPCID.Salamander2, 0.25f);
                pool.Add(NPCID.Salamander3, 0.25f);
                pool.Add(NPCID.Salamander4, 0.25f);
                pool.Add(NPCID.Salamander5, 0.25f);
                pool.Add(NPCID.Salamander6, 0.25f);
                pool.Add(NPCID.Salamander7, 0.25f);
                pool.Add(NPCID.Salamander8, 0.25f);
                pool.Add(NPCID.Salamander9, 0.25f);
            }
            if (spawnInfo.Player.ZoneUnderworldHeight)
            {
                pool.Add(NPCID.BoneSerpentHead, 0.10f);
            }
        }
        if (ModContent.GetInstance<XenonBossCleared>().DownedEaterOfWorlds)
        {
            if (spawnInfo.Player.ZoneCorrupt)
            {
                pool.Add(ModContent.NPCType<NightmareWalker>(), 0.50f);
                pool.Add(ModContent.NPCType<Evphila>(), 0.50f);
            }
        }
        if (ModContent.GetInstance<XenonBossCleared>().DownedBrainOfCthulhu)
        {
            if (spawnInfo.Player.ZoneCrimson)
            {
                pool.Add(ModContent.NPCType<CapillarieHead>(), 0.50f);
            }
        }
        if (ModContent.GetInstance<XenonBossCleared>().DownedStomachOfCthulhu)
        {
            if (spawnInfo.Player.InModBiome<Corrosion>())
            {
                pool.Add(ModContent.NPCType<TapeWormHead>(), 0.50f);
                pool.Add(ModContent.NPCType<StomachBug>(), 0.50f);
                pool.Add(ModContent.NPCType<HalfDigested>(), 0.75f);
            }
        }
        #endregion
        if (NPC.downedBoss3)
        {
            if (spawnInfo.Player.ZoneUnderworldHeight)
            {
                pool.Add(NPCID.FireImp, 0.40f);
                pool.Add(NPCID.Demon, 0.30f);
                pool.Add(NPCID.VoodooDemon, 0.10f);
            }
        }

        #endregion

        if (spawnInfo.Player.InModBiome<Mountain>() && Main.dayTime)
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<Sparrow>(), 0.4f);
            pool.Add(ModContent.NPCType<JebelSlime>(), 0.4f);
            pool.Add(ModContent.NPCType<Chipmunk>(), 0.4f);
        }

        if (spawnInfo.Player.ZoneBeach && Main.dayTime)
        {
            pool.Add(ModContent.NPCType<NavySlime>(), 0.4f);
        }

        if (spawnInfo.Player.InModBiome<UndergroundMountain>())
        {
            pool.Add(ModContent.NPCType<JebelSlime>(), 0.6f);
        }

        if (spawnInfo.Player.InModBiome<UndergroundOcean>())
        {
            pool.Add(ModContent.NPCType<NavySlime>(), 0.6f);
            if (spawnInfo.Water)
            {
                pool.Add(NPCID.Squid, 0.01f);
                pool.Add(NPCID.Shark, 0.4f);
                pool.Add(NPCID.PinkJellyfish, 0.5f);
            }
            pool.Add(NPCID.SeaSnail, 0.005f);
        }

        if (spawnInfo.Marble)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<MarbleElemental>()))
            {
                pool.Add(ModContent.NPCType<MarbleElemental>(), 0.75f);
            }
        }

        #region Corrosion Biomes
        if (spawnInfo.Player.InModBiome<Corrosion>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<LittleGastritis>(), 1.25f);
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<BigGastritis>(), 0.75f);
        }
        if (spawnInfo.Player.InModBiome<CorrosionDesert>())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<LittleGastritis>(), 1.25f);
            pool.Add(ModContent.NPCType<Gastritis>(), 1);
            pool.Add(ModContent.NPCType<BigGastritis>(), 0.75f);
            if (Main.hardMode)
            {
                pool.Add(ModContent.NPCType<FilthyMummy>(), 0.50f);
            }
        }
        if (Main.hardMode && spawnInfo.Player.InModBiome<CorrosionUnderground>() && spawnInfo.Player.ZoneSnow)
        {
            pool.Add(ModContent.NPCType<BrownPigron>(), 1f);
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

        if (spawnInfo.Player.InModBiome<Autumn>())
        {
            pool.Clear();
            
            if (Main.dayTime) pool.Add(ModContent.NPCType<SyrupSlime>(), 1);
        }
        if (spawnInfo.Player.InModBiome<UndergroundAutumn>())
        {
            pool.Clear();
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
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        if (player.GetModPlayer<XenonPlayer>().Boomed)
        {
            spawnRate = (int)(spawnRate * Boomed.RateMultiplier);
            maxSpawns = (int)(maxSpawns * Boomed.SpawnMultiplier);
        }
    }
}
public class XenonDebuffs : GlobalNPC
{
    public override bool InstancePerEntity => true;
    public bool Cleaved;
    public bool Sapped;

    public override void ResetEffects(NPC npc)
    {
        Cleaved = false;
        Sapped = false;
    }

    public override void UpdateLifeRegen(NPC npc, ref int damage)
    {
        if (npc.HasBuff<Cleaved>())
        {
            npc.lifeRegen -= 4;
        }
    }

    public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
    {
        if (Sapped)
        {
            modifiers.Defense -= 5;
        }
    }

    public override void DrawEffects(NPC npc, ref Color drawColor) {
        if (Sapped) {
            if (Main.rand.Next(4) < 3) {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 4f), npc.width + 4, npc.height + 2, ModContent.DustType<AutumnDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 140, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.1f;
                Main.dust[dust].velocity.Y += 0.5f;
            }
        }
    }
}
public class VanillaDebuffsAffectNPCS : GlobalNPC
{
    //thanks avalon :)
    public override void PostAI(NPC npc)
    {
        if (npc.HasBuff(BuffID.BrokenArmor))
        {
            npc.defense /= 2;
        }
        if (npc.HasBuff(BuffID.Slow))
        {
            npc.position += npc.velocity * -0.3f;
        }
        if (npc.HasBuff(BuffID.Chilled))
        {
            npc.position += npc.velocity * -0.35f;
        }
    }
}
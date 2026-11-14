using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Common;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Weapons.Melee.Flails;

namespace Xenon.Content.NPCs.Other
{
    public class Bandit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.PirateDeckhand];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 44;
            NPC.damage = 40;
            NPC.defense = 2;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit48;
            NPC.DeathSound = SoundID.NPCDeath50;
            NPC.value = 1000;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCAIStyleID.Fighter; 
            
            AIType = NPCID.ZombieMushroomHat;
            AnimationType = NPCID.PirateCorsair;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BanditBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Bandit")),
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode || (!NPC.AnyNPCs(Type) && NPC.AnyNPCs(ModContent.NPCType<BanditLooter>()) || (SpawnHelper.Corrosion(ref spawnInfo) || SpawnHelper.Corruption(ref spawnInfo) || SpawnHelper.Crimson(ref spawnInfo))))
            {
                return 0;
            }
            else if (Main.dayTime && spawnInfo.Player.ZoneOverworldHeight && !spawnInfo.PlayerInTown && Main.invasionType == 0)
            {
                if (NPC.downedBoss3)
                    return 0.125f;
                else if (NPC.downedBoss2)
                    return 0.1f;
                else if (NPC.downedBoss1)
                    return 0.075f;
                return 0.05f;
            }
            return 0;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 30; i++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Bandit_Gore_Head").Type, 1f);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Bandit_Gore_Arm").Type, 1f);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Bandit_Gore_Sword").Type, 1f);

                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, default, Main.rand.NextFloat(1, 1.4f));
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.3f, 4) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -3));
                }
            }
            else
            {
                for (int i = 0; i < Math.Min(hit.Damage / 3, 30) + 1; i++)
                {
                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, default, Main.rand.NextFloat(1, 1.2f));
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.3f, 4) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -3));
                }
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Aglet, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.ClimbingClaws, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Glowstick,1, 20, 40));
            npcLoot.Add(ItemDropRule.Common(ItemID.LifeCrystal, 200, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.MiningPotion, 40, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.NightOwlPotion, 40, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.RopeCoil, 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.ShinePotion, 40, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.ThrowingKnife, 5, 50, 250));
            npcLoot.Add(ItemDropRule.Common(ItemID.Torch, 1, 10, 20));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Warflail>(), 10, 1, 1));
        }
    }
}
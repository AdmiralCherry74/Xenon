using Microsoft.Xna.Framework;
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
            NPC.lifeMax = 150;
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
                for (int l = 0; l < 20; l++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 50, default, 1.5f);
                    Main.dust[dust].velocity *= 2f;
                    Main.dust[dust].noGravity = true;
                }
                int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
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
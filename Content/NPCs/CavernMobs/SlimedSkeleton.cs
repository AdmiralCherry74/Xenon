using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.NPCs.Bosses.StomachOfCthulhu.Minions;

namespace Xenon.Content.NPCs.CavernMobs
{
    public class SlimedSkeleton : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Skeleton];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
        public override void SetDefaults()
        {
            NPC.width = 36;
            NPC.height = 52;
            NPC.damage = 25;
            NPC.defense = 8;
            NPC.lifeMax = 55;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 1000;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCAIStyleID.Fighter;

            AIType = NPCID.Skeleton;
            AnimationType = NPCID.Skeleton;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<HauntedArmorBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.HauntedArmor")),
            ]);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZonePurity && SpawnHelper.Cavern(ref spawnInfo) ? 0.25f : 0;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 30; i++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("SlimedSkeleton_GoreHead").Type, 1f);

                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Bone, default, Main.rand.NextFloat(1, 1.4f));
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.3f, 4) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -3));

                    int d1 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.TintableDust, 0, 0, 175, default, Main.rand.NextFloat(1, 1.4f));
                    Main.dust[d1].color = new Color(185, 185, 185);
                    Main.dust[d1].velocity = new Vector2(Main.rand.NextFloat(-1.5f, 5) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -5));
                }
            }
            else
            {
                for (int i = 0; i < Math.Min(hit.Damage / 3, 30) + 1; i++)
                {
                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Bone, default, Main.rand.NextFloat(1, 1.2f));
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.3f, 4) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -3));

                    int d1 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.TintableDust, 0, 0, 175, default, Main.rand.NextFloat(1, 1.2f));
                    Main.dust[d1].color = new Color(185, 185, 185);
                    Main.dust[d1].velocity = new Vector2(Main.rand.NextFloat(-1.5f, 5) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -5));
                }
            }
        }
        public override void OnKill()
        {
            if (Main.expertMode)
            {
                Vector2 spawnPos = NPC.Center + new Vector2(0, -4);
                int spawnType = ModContent.NPCType<SpikedWhiteSlime>();

                NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnPos.X, (int)spawnPos.Y, spawnType);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.MilkCarton, 670, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.AncientIronHelmet, 1000, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.AncientGoldHelmet, 1000, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoneSword, 500, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Skull, 200, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Hook, 25, 1, 1));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WhiteGel>(), 3, 1, 3));
        }
    }
}
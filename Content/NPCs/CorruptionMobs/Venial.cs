using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Placeable.Banner;

namespace Xenon.Content.NPCs.CorruptionMobs
{
    public class Venial : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 12;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 16;
            NPC.damage = 19;
            NPC.defense = 13;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit13;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 30;
            NPC.knockBackResist = 0.50f;
            NPC.aiStyle = NPCAIStyleID.GiantTortoise;
            AnimationType = NPCID.GiantShelly;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<SporeSlimeBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Venial")),
            ]);
        }

        public override void AI()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
        }
        public override void OnKill()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneCorrupt && NPC.downedBoss2 || spawnInfo.Player.ZoneCorrupt && spawnInfo.Player.ZoneDirtLayerHeight && NPC.downedBoss2 || spawnInfo.Player.ZoneCorrupt && spawnInfo.Player.ZoneRockLayerHeight && NPC.downedBoss2)
            {
                return SpawnCondition.Crimson.Chance * 0.50f;
            }
            return 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 30; i++)
                {
                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.TintableDust, 0, 0, 175, default, Main.rand.NextFloat(1, 1.2f));
                    Main.dust[d].color = new Color(16, 94, 135);
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.5f, 5) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -5));
                }
            }
            else
                for (int i = 0; i < Math.Min(hit.Damage / 3, 30) + 1; i++)
                {
                    int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.TintableDust, 0, 0, 175, default, Main.rand.NextFloat(1, 1.2f));
                    Main.dust[d].color = new Color(16, 94, 135);
                    Main.dust[d].velocity = new Vector2(Main.rand.NextFloat(-1.3f, 4) * MathHelper.Clamp(NPC.velocity.X, -1, 1), Main.rand.NextFloat(-1, -3));
                }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2, 2, 5));
            npcLoot.Add(ItemDropRule.Common(ItemID.GlowingSnail, 4));
        }
    }
}
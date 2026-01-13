using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Consumables.GlugGlugs;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Weapons.Melee.Swords;

namespace Xenon.Content.NPCs.UndergroundMobs
{
    public class Mimicling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.IceMimic];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 28;
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = 50000;
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 25;

            AIType = NPCID.Mimic;
            AnimationType = NPCID.IceMimic;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<MimiclingBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Mimicling")),
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
            if (spawnInfo.Player.ZoneNormalUnderground && !NPC.AnyNPCs(Type))

            {
                {
                    return SpawnCondition.Underground.Chance * 1f;

                }
            }
            return 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int l = 0; l < 20; l++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default, 1.5f);
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
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PainPills>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RubberHandleSword>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LaserSight>(), 1, 1, 1));
        }
    }
}
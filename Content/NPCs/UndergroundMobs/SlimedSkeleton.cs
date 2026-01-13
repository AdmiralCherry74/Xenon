using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Placeable.Banner;

namespace Xenon.Content.NPCs.UndergroundMobs
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
            NPC.aiStyle = 3;

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
            if (spawnInfo.Player.ZoneNormalCaverns && !NPC.AnyNPCs(Type))
            {
                {
                    return SpawnCondition.Cavern.Chance * 0.25f;


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
            npcLoot.Add(ItemDropRule.Common(ItemID.MilkCarton, 670, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.AncientIronHelmet, 1000, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.AncientGoldHelmet, 1000, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoneSword, 500, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Skull, 200, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Hook, 25, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpikedGel>(), 3, 1, 3));
        }
    }
}
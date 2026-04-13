using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.Counterable;
using Xenon.Content.Items.Consumables;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Weapons.Melee.Swords;

namespace Xenon.Content.NPCs.CatacombMobs
{
    public class SmallFallenSurvivor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 44;
            NPC.scale = 0.9f;
            NPC.damage = 26;
            NPC.defense = 5;
            NPC.lifeMax = 170;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 9000;
            NPC.knockBackResist = 0.6f;
            NPC.aiStyle = NPCAIStyleID.Fighter;

            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<BanditBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.SmallFallenSurvivor")),
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

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextBool(3) && Main.expertMode)
            {
                target.AddBuff(ModContent.BuffType<Gnashed>(), 300);
            }
            else if (Main.rand.NextBool(3) && Main.masterMode)
            {
                target.AddBuff(ModContent.BuffType<Gnashed>(), 600);
            }
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
            //npcLoot.Add(ItemDropRule.Common(ItemID.Aglet, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenPickaxeHead>(), 10, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Scarlet>(), 40, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlatinumKey>(), 152, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brain>(), 2, 1, 3));
        }
    }
}
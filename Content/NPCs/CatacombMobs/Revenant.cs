using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables;
using Xenon.Content.Items.Materials;

namespace Xenon.Content.NPCs.CatacombMobs
{
    public class Revenant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Wraith];

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
            NPC.scale = 1.17f;
            NPC.damage = 38;
            NPC.defense = 6;
            NPC.lifeMax = 60;
            NPC.noTileCollide = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = 900;
            NPC.knockBackResist = 0.6f;
            NPC.aiStyle = NPCAIStyleID.HoveringFighter;

            AIType = NPCID.Wraith;
            AnimationType = NPCID.Wraith;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<BanditBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Revenant")),
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
            if (Main.rand.NextBool(3) && !Main.expertMode && !Main.masterMode)
            {
                target.AddBuff(BuffID.Cursed, 300);
            }
            else if (Main.rand.NextBool(3) && Main.expertMode && !Main.masterMode)
            {
                target.AddBuff(BuffID.Cursed, 450);
            }
            else if (Main.rand.NextBool(3) && Main.masterMode && !Main.expertMode)
            {
                target.AddBuff(BuffID.Cursed, 600);
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
            npcLoot.Add(ItemDropRule.Common(ItemID.Nazar, 100, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlatinumKey>(), 152, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brain>(), 2, 1, 3));
        }
    }
}
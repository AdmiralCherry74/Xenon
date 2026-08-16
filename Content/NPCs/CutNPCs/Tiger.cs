using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Content.NPCs.CutNPCs
{
    public class Tiger : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Wolf];

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
            NPC.damage = 31;
            NPC.defense = 4;
            NPC.lifeMax = 125;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 2000;
            NPC.knockBackResist = 0.3f;
            NPC.aiStyle = NPCAIStyleID.Unicorn; 
            AIType = NPCID.Wolf;
            AnimationType = NPCID.Wolf;
			//Banner = NPC.type;
			//BannerItem = ModContent.ItemType<TigerBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Tiger")),
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
                target.AddBuff(ModContent.BuffType<Gnashed>(), 600);
            }
            else if (Main.rand.NextBool(2) && Main.masterMode)
            {
                target.AddBuff(ModContent.BuffType<Gnashed>(), 900);
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
            npcLoot.Add(ItemDropRule.Common(ItemID.MudBlock, 5, 10, 20));
        }
    }
}
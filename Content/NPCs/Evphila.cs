using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Placeable.Banner;

namespace Xenon.Content.NPCs
{
    public class Evphila : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.WallCreeper];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 55;
            NPC.height = 28;
            NPC.damage = 20;
            NPC.defense = 10;
            NPC.lifeMax = 90;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 1000;
            NPC.knockBackResist = 0.75f;
            NPC.aiStyle = 3; 
            
            AIType = NPCID.WallCreeper;
            AnimationType = NPCID.WallCreeper;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<EvphilaBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Evphila")),
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
            if (spawnInfo.Player.ZoneCorrupt && NPC.downedBoss2)

                {
                    {
                    return SpawnCondition.Corruption.Chance * 0.5f;

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
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + (NPC.height / 2) - 15f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
            }
        }
         public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 3, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Vertebrae, 3, 1, 1));
        }
    }
}
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.NPCs.Other
{
    public class SulfurGoldfish : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.CorruptGoldfish];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 22;
            NPC.damage = 30;
            NPC.defense = 7;
            NPC.lifeMax = 105;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 500;
            NPC.knockBackResist = 1f;
            NPC.aiStyle = NPCAIStyleID.Piranha;

            AIType = NPCID.CorruptGoldfish;
            AnimationType = NPCID.CorruptGoldfish;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<HauntedArmorBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.SulfurGoldfish")),
            ]);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int i = 0; i < 30; i++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("SulfurGoldfish_Gore").Type, 1f);

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
    }
}
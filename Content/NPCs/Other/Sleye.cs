using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Placeable.Tile.Natural.Stone;

namespace Xenon.Content.NPCs.Other
{
    public class Sleye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 22;
            NPC.damage = 12;
            NPC.defense = 1;
            NPC.lifeMax = 45;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 2000;
            NPC.knockBackResist = 1f;
            NPC.aiStyle = NPCAIStyleID.Slime;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<SporeSlimeBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Sleye")),
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
            if (spawnInfo.Player.ZoneForest & Main.bloodMoon)
            {
                return 0.75f;
            }
            return 0;
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
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.Lens, 3, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 100, 1, 1));
        }
    }
}
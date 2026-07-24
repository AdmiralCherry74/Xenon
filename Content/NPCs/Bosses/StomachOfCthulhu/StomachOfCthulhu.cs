using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;
using Xenon.Content.NPCs.CorrosionMobs;
using Xenon.Content.Projectiles.Boss;

namespace Xenon.Content.NPCs.Bosses.StomachOfCthulhu
{
    [AutoloadBossHead]
    public class StomachOfCthulhu : ModNPC
    {
        private enum StomachAIState
        {
            Teleport,
            BubbleAllAround
        }
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public ref float AI_Timer2 => ref NPC.ai[2];

        public override void SetDefaults()
        {
            NPC.width = 150;
            NPC.height = 150;
            NPC.damage = 28;
            NPC.defense = 14;
            NPC.lifeMax = 3500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuDeathBurp") { Pitch = -0.75f, Volume = 2f, PitchVariance = 0f, MaxInstances = 5 };
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.netAlways = true;
            NPC.npcSlots = 10f;
            Music = MusicID.Boss2;
        }
        #region Burp SFX
        static SoundStyle Burp1 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp1")
        {
            Volume = 10f,
            Pitch = 0f,
            PitchVariance = 0f,
            MaxInstances = 5,
        };
        static SoundStyle Burp2 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp2")
        {
            Volume = 10f,
            Pitch = 0f,
            PitchVariance = 0f,
            MaxInstances = 5,
        };
        static SoundStyle Burp3 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp3")
        {
            Volume = 10f,
            Pitch = 0f,
            PitchVariance = 0f,
            MaxInstances = 5,
        };
        #endregion
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Trophies are spawned with 1/10 chance
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrescentTrophy>(), 10));

            LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());

            // Boss masks are spawned with 1/7 chance
            //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CrescentMask>(), 7));

            //Material drops
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<IngestaneOre>(), 1, 40, 90));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<FreshChyme>(), 1, 40, 90));

            //Weapon drops
            /*notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CrescentStaff>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<StellarGem>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CrescentReaper>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MoonsHarmony>(), 4));*/

            npcLoot.Add(notExpertRule);

            //Do Treasure Bag
            //npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<CrescentBag>()));

            //Do Master Mode drops
            /*npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<CrescentRelicItem>()));
            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MoondustInABottle>(), 4));*/
        }
        public override void AI()
        {


            Player player = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
                NPC.TargetClosest();

            if (player.dead || !player.active)
            {

                //NPC.alpha++;
                //.velocity.Y += 1;

                if (NPC.alpha == 255)
                {
                    NPC.EncourageDespawn(10);
                }
                return;
            }

            switch (AI_State)
            {
                case (float)StomachAIState.Teleport:
                    Teleport(NPC, player);
                    break;
                case (float)StomachAIState.BubbleAllAround:
                    Bubble(NPC, player);
                    break;
            }


            if (NPC.alpha >= 255)
            {
                NPC.alpha = 255;
            }
            else if (NPC.alpha < 0)
            {
                NPC.alpha = 0;
            }
        }
        private void Teleport(NPC npc, Player player)
        {

            Vector2 positionToTeleport = Vector2.Zero;




            AI_Timer++;

            if (AI_Timer <= 100)
            {
                npc.damage = 0;
                npc.dontTakeDamage = true;
                npc.alpha += 2;
            }
            else if (AI_Timer >= 100)
            {
                npc.alpha -= 2;
                if (npc.alpha == 0)
                {
                    npc.damage = 14;
                    npc.dontTakeDamage = false;
                }
            }

            if (AI_Timer == 100)
                npc.Center = player.Center;

            if (AI_Timer >= 300)
            {
                AI_Timer = 0;
                AI_State = (float)StomachAIState.BubbleAllAround;
                npc.netUpdate = true;
            }

        }
        private void Bubble(NPC npc, Player player)
        {
            AI_Timer++;

            if (AI_Timer <= 1)
            {
                SpewBurpGasBubbleShit(npc, player);
            }
            if (AI_Timer == 100)
            {
                SpewBurpGasBubbleShit(npc, player);
            }
            if (AI_Timer == 200)
            {
                SpewBurpGasBubbleShit(npc, player);
                NPC.NewNPC(npc.GetSource_FromAI(), (int)npc.Center.X + Main.rand.Next(-28, -23), (int)npc.Center.Y - 100, ModContent.NPCType<GastritisEcho>());
                NPC.NewNPC(npc.GetSource_FromAI(), (int)npc.Center.X + Main.rand.Next(-28, -23), (int)npc.Center.Y - 100, ModContent.NPCType<HalfDigestedEcho>());
            }
            if (AI_Timer >= 300)
            {
                AI_Timer = 0;
                AI_State = (float)StomachAIState.Teleport;
                npc.netUpdate = true;
            }
        }
        private void SpewBurpGasBubbleShit(NPC npc, Player player)
        {
           if (Main.rand.Next(1, 4) == 1)
           {
               SoundEngine.PlaySound(Burp1, npc.Center);
           }
           else if (Main.rand.Next(1, 4) == 2)
           {
               SoundEngine.PlaySound(Burp2, npc.Center);
           }
           else
           {
               SoundEngine.PlaySound(Burp3, npc.Center);
           }
           for (int j = 0; j < 6; j++)
           {

               Vector2 upwardsVector = Main.rand.NextVector2Unit(MathHelper.Pi / 4, MathHelper.Pi / 2) * Main.rand.NextFloat();
               float speed = 5f;
               Vector2 normalized = upwardsVector.SafeNormalize(Vector2.UnitY);
               Vector2 moveTo = normalized * -speed;

               Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center + new Vector2(-25, -100), moveTo, ModContent.ProjectileType<StomachBubble>(), 10, 4f);
           }

           for (int i = 0; i < 50; i++)
           {
               Vector2 speed = Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Main.rand.NextFloat();
               Dust SOCBileLight = Dust.NewDustPerfect(npc.Center + new Vector2(-25, -98), DustID.CursedTorch, speed * -5);
               Dust SOCBile = Dust.NewDustPerfect(npc.Center + new Vector2(-25, -98), ModContent.DustType<StomachOfCthulhusWaterSplash>(), speed * -5);
               SOCBileLight.noGravity = true;
               SOCBileLight.scale = 2f;
               SOCBile.scale = 2f;
           }
        
        }
    }
}

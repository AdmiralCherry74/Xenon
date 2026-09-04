using Avalon.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Common.Globals.XenonNPCGlobals;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Dusts.WaterSplashes;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Items.Consumables.TreasureBags;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Other;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Projectiles.Boss.StomachOfCthulhu;
using Terraria.DataStructures;
using System;

namespace Xenon.Content.NPCs.Bosses.StomachOfCthulhu
{
    [AutoloadBossHead]
    public class StomachOfCthulhu : ModNPC
    {
        public int[] Adds;
        public int[] Hooks = [-1, -1, -1, -1, -1, -1];

        private enum StomachAIState
        {
            Teleport,
            BubbleAllAround
        }
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        
        private int despawnTimer = 1000;
        private float hoverDistance = 280f;
        private bool pauseMovement = true;

        private bool acidChargeDir = false; //false = left, true = right


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
        static SoundStyle RareBurp = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurpRare")
        {
            Volume = 10f,
            Pitch = 0f,
            PitchVariance = 0f,
            MaxInstances = 5,
        };
        #endregion

        public override void SetDefaults()
        {
            NPC.width = 146;
            NPC.height = 164;
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
            NPC.npcSlots = 6f;
            Music = MusicID.Boss2;
            SpawnModBiomes = new int[] { ModContent.GetInstance<Biomes.Corrosion.Corrosion>().Type, ModContent.GetInstance<Biomes.Corrosion.CorrosionUnderground>().Type };
        }
        
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }
        public override void AI()
        {
            // Variables
            Vector2 vector = NPC.Center;

            XenonGlobalNPC.corrosionBoss = NPC.whoAmI;

            // Spawn hooks
            if (AI_State == 0f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                AI_State = 1f;
                Hooks[0] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                Hooks[1] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                Hooks[2] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                Hooks[3] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                Hooks[4] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
                Hooks[5] = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector.X, (int)vector.Y, ModContent.NPCType<StomachOfCthulhuHook>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
            }

            Player target = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || target.dead || !target.active)
                NPC.TargetClosest();

            SpawnAnimation(target);
            Movement(target);
            DoAttack(target);
        }

        public void Movement(Player target)
        {

            if (pauseMovement) return;

            float xTopSpeed = 5f;
            float climbTopSpeed = 3f;
            float fallTopSpeed = 7f;






























































            float velocityChange = 0.2f;
            float fallingVelocityChange = 0.3f;
            float velocityDecay = 0.1f;

            bool maxXSpeed = Math.Abs(NPC.velocity.X) < xTopSpeed;
            bool maxClimbSpeed = Math.Abs(NPC.velocity.Y) < climbTopSpeed;
            bool maxFallSpeed = NPC.velocity.Y < fallTopSpeed;

            float targetX = target.Center.X;
            float targetY = target.Bottom.Y - hoverDistance;

            float compareX = NPC.Center.X;
            float compareY = NPC.Center.Y;

            // Velocity Decay
            if (NPC.velocity.X > 0)
            {
                NPC.velocity.X -= velocityDecay;
                if (!(NPC.velocity.X > 0)) NPC.velocity.X = 0;
            }
            else if (NPC.velocity.X < 0)
            {
                NPC.velocity.X += velocityDecay;
                if (!(NPC.velocity.X < 0)) NPC.velocity.X = 0;
            }

            if (NPC.velocity.Y > 0)
            {
                NPC.velocity.Y -= velocityDecay;
                if (!(NPC.velocity.Y > 0)) NPC.velocity.Y = 0;
            }
            else if (NPC.velocity.Y < 0)
            {
                NPC.velocity.Y += velocityDecay;
                if (!(NPC.velocity.Y < 0)) NPC.velocity.Y = 0;
            }

            // Despawn Check
            if (target.dead || !target.active || !XenonPlayer.ZoneCorrosion(target))
            {
                if(maxFallSpeed) NPC.velocity.Y += fallingVelocityChange;
                NPC.EncourageDespawn(10);
                XenonGlobalNPC.corrosionBoss = -1;
                return;
            }
            
            // Movement

            if (targetX > compareX && maxXSpeed) NPC.velocity.X += velocityChange;
            if (targetX < compareX && maxXSpeed) NPC.velocity.X -= velocityChange;
            
            if (targetY > NPC.position.Y && maxClimbSpeed) NPC.velocity.Y += velocityChange;
            if (targetY < NPC.position.Y && maxClimbSpeed) NPC.velocity.Y -= velocityChange;
        
        }

        // Hook Max Check. Currently not used for now.
        /*
        public bool checkGround(float moveX, float moveY, float maxReachDistance)
        {
            for (int idx = 0; idx < Hooks.Length; idx++)
            {
                NPC targetHook = Main.npc[Hooks[idx]];
                float hookX = targetHook.position.X;
                float hookY = targetHook.position.Y;

                float changeX = moveX + 

                float hookDistance = (float)Math.Sqrt(hookX * hookX + hookY * hookY);
                if (hookDistance > maxReachDistance)
                {
                    targetHook.ai[3] = 1;
                    return false; 
                }
            }

            return true;
        }
        */

        public void DoAttack(Player target)
        {
            /* AI 0 phases
                0 Spawn Start
                1 Fables Spawn Animation (Skip if fables isn't on)
                2 Waiting
                3 Gass Bubble
                4 Spawn Adds
                5 Bug Bombs
                6 Acid Charge
            */
            int timeBetweenAttacks = 180;

            if (AI_State < 2f)
            {
                return;
            }

            if (AI_State == 2f)
            {
                AI_Timer++;

                if (AI_Timer > timeBetweenAttacks)
                {
                    AI_State = Main.rand.Next(3, 7);
                    AI_Timer = 0f;
                }

                return;
            }

            #region Gas Bubbles
            if (AI_State == 3f)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        SoundEngine.PlaySound(Burp1, NPC.Center);
                        break;
                    case 1:
                        SoundEngine.PlaySound(Burp2, NPC.Center);
                        break;
                    case 2:
                        SoundEngine.PlaySound(Burp3, NPC.Center);
                        break;
                }
                for (int j = 0; j < 4; j++)
                {
                    Vector2 upwardsVector = Main.rand.NextVector2Unit(MathHelper.Pi / 4, MathHelper.Pi / 2) * Main.rand.NextFloat();
                    float speed = 5f;
                    Vector2 normalized = upwardsVector.SafeNormalize(Vector2.UnitY);
                    Vector2 moveTo = normalized * -speed;

                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center + new Vector2(-25, -100), moveTo, ModContent.ProjectileType<StomachBubble>(), 10, 4f);
                }

                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Main.rand.NextFloat();
                    Dust SOCBileLight = Dust.NewDustPerfect(NPC.Center + new Vector2(-25, -98), DustID.CursedTorch, speed * -5);
                    Dust SOCBile = Dust.NewDustPerfect(NPC.Center + new Vector2(-25, -98), ModContent.DustType<StomachOfCthulhusWaterSplash>(), speed * -5);
                    SOCBileLight.noGravity = true;
                    SOCBileLight.scale = 2f;
                    SOCBile.scale = 2f;
                }

                AI_State = 2f;
                AI_Timer = 0f;

                return;
            }
            #endregion

            if (AI_State == 4f)
            {
                AI_State = 3f;
                AI_Timer = 0f;

                return;
            }

            if (AI_State == 5f)
            {
                AI_State = 3f;
                AI_Timer = 0f;

                return;
            }

            #region Acid Charge
            if (AI_State == 6f)
            {
                pauseMovement = true;

                AI_Timer++;

                if (AI_Timer == 1f)
                {
                    if (target.position.X > NPC.Center.X) { NPC.velocity.X = -9; acidChargeDir = false; } 
                    if (target.position.X < NPC.Center.X) { NPC.velocity.X = 9; acidChargeDir = true; }
                }

                if (AI_Timer > 1f)
                {
                    float chargeTopSpeed = 10f;
                    bool maxChargeSpeed = Math.Abs(NPC.velocity.X) < chargeTopSpeed;

                    if (acidChargeDir && maxChargeSpeed) NPC.velocity.X -= 0.15f; 
                    else if (maxChargeSpeed) NPC.velocity.X += 0.15f;
                    
                    if (
                        (acidChargeDir && NPC.velocity.X < 0)
                        || (!acidChargeDir && NPC.velocity.X > 0)
                    )
                    if (AI_Timer % 5 == 0)
                    {
                        Vector2 upwardsVector = Main.rand.NextVector2Unit(MathHelper.Pi / 4, MathHelper.Pi / 2) * Main.rand.NextFloat();
                        float speed = 2f;
                        Vector2 normalized = upwardsVector.SafeNormalize(Vector2.UnitY);
                        Vector2 moveTo = normalized * -speed;

                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center + new Vector2(-25, -100), moveTo, ModContent.ProjectileType<DimitriTreatmentProj>(), 13, 8f);
                    }
                }

                if (AI_Timer >= 140f)
                {
                    pauseMovement = false;
                    AI_State = 2f;
                    AI_Timer = 0f;
                }
            }
            #endregion

            
        }

        public void SpawnAnimation(Player target)
        {
            //Skip for now as Fables check isn't implemented

            if (NPC.ai[0] == 1)
            {
                if (true)
                {
                    NPC.ai[0] = 2;
                    pauseMovement = false;
                }
                else { /*Cutscene Logic*/ }
            }
        }

        public override void OnKill()
        {
            if (!NPC.downedBoss2 || Main.rand.NextBool(2))
            {
                WorldGen.spawnMeteor = true;
            }
            if (!NPC.downedBoss2)
            {
                NPC.SetEventFlagCleared(ref NPC.downedBoss2, -1);
            }
            if (!ModContent.GetInstance<XenonBossCleared>().DownedStomachOfCthulhu)
            {
                NPC.SetEventFlagCleared(ref ModContent.GetInstance<XenonBossCleared>().DownedStomachOfCthulhu, -1);
            }
            XenonGlobalNPC.corrosionBoss = -1;
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
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<BurpGun>(), 3, 1, 1));

            //Weapon drops
            /*notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CrescentStaff>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<StellarGem>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CrescentReaper>(), 4));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MoonsHarmony>(), 4));*/

            npcLoot.Add(notExpertRule);

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SOCTreasureBag>()));

            //Do Master Mode drops
            /*npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<CrescentRelicItem>()));
            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MoondustInABottle>(), 4));*/
        }
    }
}

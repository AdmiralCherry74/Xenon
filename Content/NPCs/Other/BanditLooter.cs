using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using Terraria.Localization;
using Xenon.Content.Items.Placeable.Banner;

namespace Xenon.Content.NPCs.Other
{
    public class BanditLooter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BoneThrowingSkeleton];

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
            NPC.damage = 5;
            NPC.defense = 4;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit48;
            NPC.DeathSound = SoundID.NPCDeath50;
            NPC.value = 5000;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = -1;

            AnimationType = NPCID.BoneThrowingSkeleton;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BanditLooterBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.BanditLooter")),
            ]);
        }

        public override void AI()
        {
            if (Main.player[NPC.target].position.Y + Main.player[NPC.target].height == NPC.position.Y + NPC.height)
            {
                NPC.directionY = -1;
            }
            bool flag = false;
            Vector2 val;
            Rectangle hitbox;
            bool flag23 = false;
            bool flag24 = false;
            if (NPC.velocity.X == 0f)
            {
                flag24 = true;
            }
            if (NPC.justHit)
            {
                flag24 = false;
            }
            int num154 = 60;
            bool flag25 = false;
            bool flag26 = false;
            bool flag27 = false;
            bool flag2 = true;

            if (NPC.ai[2] > 0f)
            {
                flag2 = false;
            }

            if (NPC.velocity.Y == 0f && (NPC.velocity.X > 0f && NPC.direction < 0 || NPC.velocity.X < 0f && NPC.direction > 0))
            {
                flag25 = true;
            }
            if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= num154 || flag25)
            {
                NPC.ai[3] += 1f;
            }
            else if ((double)Math.Abs(NPC.velocity.X) > 0.9 && NPC.ai[3] > 0f)
            {
                NPC.ai[3] -= 1f;
            }
            if (NPC.ai[3] > num154 * 10)
            {
                NPC.ai[3] = 0f;
            }
            if (NPC.justHit)
            {
                NPC.ai[3] = 0f;
            }
            if (NPC.ai[3] == num154)
            {
                NPC.netUpdate = true;
            }
            hitbox = Main.player[NPC.target].Hitbox;
            if (hitbox.Intersects(NPC.Hitbox))
            {
                NPC.ai[3] = 0f;
            }

            if (NPC.ai[3] < num154 && NPC.DespawnEncouragement_AIStyle3_Fighters_NotDiscouraged(NPC.type, NPC.position, NPC))
            {
                if (NPC.shimmerTransparency < 1f)
                {
                }
                NPC.TargetClosest();
                if (NPC.directionY > 0 && Main.player[NPC.target].Center.Y <= NPC.Bottom.Y)
                {
                    NPC.directionY = -1;
                }
            }
            else if (!(NPC.ai[2] > 0f) || !NPC.DespawnEncouragement_AIStyle3_Fighters_CanBeBusyWithAction(NPC.type))
            {
                if (Main.IsItDay() && (double)(NPC.position.Y / 16f) < Main.worldSurface && NPC.type != NPCID.Gnome && NPC.type != NPCID.RockGolem)
                {
                    NPC.EncourageDespawn(10);
                }
                if (NPC.velocity.X == 0f)
                {
                    if (NPC.velocity.Y == 0f)
                    {
                        NPC.ai[0] += 1f;
                        if (NPC.ai[0] >= 2f)
                        {
                            NPC.direction *= -1;
                            NPC.spriteDirection = NPC.direction;
                            NPC.ai[0] = 0f;
                        }
                    }
                }
                else
                {
                    NPC.ai[0] = 0f;
                }
                if (NPC.direction == 0)
                {
                    NPC.direction = 1;
                }
            }

            {
                bool flag8 = false;
                bool flag9 = false;
                bool flag10 = true;
                int num62 = -1;
                int num63 = -1;
                if (NPC.ai[1] > 0f)
                {
                    NPC.ai[1] -= 1f;
                }
                if (NPC.justHit)
                {
                    NPC.ai[1] = 30f;
                    NPC.ai[2] = 0f;
                }
                int num64 = 100;
                bool flag11 = false;
                int num65 = num64 / 2;

                if (NPC.confused)
                {
                    NPC.ai[2] = 0f;
                }
                if (NPC.ai[2] > 0f)
                {
                    if (flag10)
                    {
                        NPC.TargetClosest();
                    }
                    if (NPC.ai[1] == num65)
                    {
                        float num66 = 11f;
                        Vector2 chaserPosition2 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        float num68 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - chaserPosition2.X;
                        float num69 = Math.Abs(num68) * 0.1f;
                        float num70 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f - chaserPosition2.Y - num69;

                        num68 += Main.rand.Next(-40, 41);
                        num70 += Main.rand.Next(-40, 41);

                        float num71 = (float)Math.Sqrt(num68 * num68 + num70 * num70);
                        NPC.netUpdate = true;
                        num71 = num66 / num71;
                        num68 *= num71;
                        num70 *= num71;
                        int projDmg = 25;
                        int projToShoot = ProjectileID.ThrowingKnife;
                        Player player3 = Main.player[NPC.target];
                        Vector2? vector27 = null;
                        if (vector27.HasValue)
                        {
                            Utils.ChaseResults chaseResults2 = Utils.GetChaseResults(chaserPosition2, num66, vector27.Value, player3.velocity);
                            if (chaseResults2.InterceptionHappens)
                            {
                                Vector2 val4 = Utils.FactorAcceleration(chaseResults2.ChaserVelocity, chaseResults2.InterceptionTime, new Vector2(0f, 0.1f), 15);
                                num68 = val4.X;
                                num70 = val4.Y;
                            }
                        }
                        chaserPosition2.X += num68;
                        chaserPosition2.Y += num70;
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            SoundEngine.PlaySound(SoundID.Item1, NPC.position);
                            int proj = Projectile.NewProjectile(NPC.GetSource_FromAI(), chaserPosition2.X, chaserPosition2.Y, num68, num70, projToShoot, projDmg, 0f, Main.myPlayer);
                            Main.projectile[proj].hostile = true;
                            Main.projectile[proj].friendly = false;
                            Main.projectile[proj].velocity *= 1.3f;
                        }
                        if (Math.Abs(num70) > Math.Abs(num68) * 2f)
                        {
                            if (num70 > 0f)
                            {
                                NPC.ai[2] = 1f;
                            }
                            else
                            {
                                NPC.ai[2] = 5f;
                            }
                        }
                        else if (Math.Abs(num68) > Math.Abs(num70) * 2f)
                        {
                            NPC.ai[2] = 3f;
                        }
                        else if (num70 > 0f)
                        {
                            NPC.ai[2] = 2f;
                        }
                        else
                        {
                            NPC.ai[2] = 4f;
                        }
                    }
                    if (NPC.velocity.Y != 0f && !flag9 || NPC.ai[1] <= 0f)
                    {
                        NPC.ai[2] = 0f;
                        NPC.ai[1] = 0f;
                    }
                    else if (!flag8 || num62 != -1 && NPC.ai[1] >= num62 && NPC.ai[1] < num62 + num63 && (!flag9 || NPC.velocity.Y == 0f))
                    {
                        NPC.velocity.X *= 0.9f;
                        NPC.spriteDirection = NPC.direction;
                    }
                }
                if ((NPC.ai[2] <= 0f || flag8) && (NPC.velocity.Y == 0f || flag9) && NPC.ai[1] <= 0f && !Main.player[NPC.target].dead)
                {
                    bool flag13 = Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height);
                    if (Main.player[NPC.target].stealth == 0f && Main.player[NPC.target].itemAnimation == 0)
                    {
                        flag13 = false;
                    }
                    if (flag13)
                    {
                        float num77 = 10f;
                        Vector2 vector28 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        float num79 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector28.X;
                        float num80 = Math.Abs(num79) * 0.1f;
                        float num81 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f - vector28.Y - num80;
                        num79 += Main.rand.Next(-40, 41);
                        num81 += Main.rand.Next(-40, 41);
                        float num82 = (float)Math.Sqrt(num79 * num79 + num81 * num81);
                        float num83 = 700f;
                        if (num82 < num83)
                        {
                            NPC.netUpdate = true;
                            NPC.velocity.X *= 0.5f;
                            num82 = num77 / num82;
                            num79 *= num82;
                            num81 *= num82;
                            NPC.ai[2] = 3f;
                            NPC.ai[1] = num64;
                            if (Math.Abs(num81) > Math.Abs(num79) * 2f)
                            {
                                if (num81 > 0f)
                                {
                                    NPC.ai[2] = 1f;
                                }
                                else
                                {
                                    NPC.ai[2] = 5f;
                                }
                            }
                            else if (Math.Abs(num79) > Math.Abs(num81) * 2f)
                            {
                                NPC.ai[2] = 3f;
                            }
                            else if (num81 > 0f)
                            {
                                NPC.ai[2] = 2f;
                            }
                            else
                            {
                                NPC.ai[2] = 4f;
                            }
                        }
                    }
                }
                if (NPC.ai[2] <= 0f || flag8 && (num62 == -1 || !(NPC.ai[1] >= num62) || !(NPC.ai[1] < num62 + num63)))
                {
                    float num84 = 1f;
                    float num85 = 0.07f;
                    float num86 = 0.8f;
                    bool flag14 = false;
                    if (NPC.velocity.X < 0f - num84 || NPC.velocity.X > num84 || flag14)
                    {
                        if (NPC.velocity.Y == 0f)
                        {
                            NPC.velocity *= num86;
                        }
                    }
                    else if (NPC.velocity.X < num84 && NPC.direction == 1)
                    {
                        NPC.velocity.X += num85;
                        if (NPC.velocity.X > num84)
                        {
                            NPC.velocity.X = num84;
                        }
                    }
                    else if (NPC.velocity.X > 0f - num84 && NPC.direction == -1)
                    {
                        NPC.velocity.X -= num85;
                        if (NPC.velocity.X < 0f - num84)
                        {
                            NPC.velocity.X = 0f - num84;
                        }
                    }
                }
            }
            if (NPC.velocity.Y == 0f || flag)
            {
                int num91 = (int)(NPC.position.Y + NPC.height + 7f) / 16;
                int num92 = (int)(NPC.position.Y - 9f) / 16;
                int num93 = (int)NPC.position.X / 16;
                int num94 = (int)(NPC.position.X + NPC.width) / 16;
                int num205 = (int)(NPC.position.X + 8f) / 16;
                int num95 = (int)(NPC.position.X + NPC.width - 8f) / 16;
                bool flag15 = false;
                for (int num96 = num205; num96 <= num95; num96++)
                {
                    if (num96 >= num93 && num96 <= num94 && Main.tile[num96, num91] == null)
                    {
                        flag15 = true;
                        continue;
                    }
                    if (Main.tile[num96, num92] != null && Main.tile[num96, num92].HasUnactuatedTile && Main.tileSolid[Main.tile[num96, num92].TileType])
                    {
                        flag23 = false;
                        break;
                    }
                    if (!flag15 && num96 >= num93 && num96 <= num94 && Main.tile[num96, num91].HasUnactuatedTile && Main.tileSolid[Main.tile[num96, num91].TileType])
                    {
                        flag23 = true;
                    }
                }
                if (!flag23 && NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = 0f;
                }
                if (flag15)
                {
                    return;
                }
            }
            if (NPC.velocity.Y >= 0f && NPC.directionY != 1)
            {
                int num97 = 0;
                if (NPC.velocity.X < 0f)
                {
                    num97 = -1;
                }
                if (NPC.velocity.X > 0f)
                {
                    num97 = 1;
                }
                Vector2 vector30 = NPC.position;
                vector30.X += NPC.velocity.X;
                int num98 = (int)((vector30.X + NPC.width / 2 + (NPC.width / 2 + 1) * num97) / 16f);
                int num100 = (int)((vector30.Y + NPC.height - 1f) / 16f);
                if (WorldGen.InWorld(num98, num100, 4))
                {
                    if (num98 * 16 < vector30.X + NPC.width && num98 * 16 + 16 > vector30.X && (Main.tile[num98, num100].HasUnactuatedTile && !Main.tile[num98, num100].TopSlope && !Main.tile[num98, num100 - 1].TopSlope && Main.tileSolid[Main.tile[num98, num100].TileType] && !Main.tileSolidTop[Main.tile[num98, num100].TileType] || Main.tile[num98, num100 - 1].IsHalfBlock && Main.tile[num98, num100 - 1].HasUnactuatedTile) && (!Main.tile[num98, num100 - 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num98, num100 - 1].TileType] || Main.tileSolidTop[Main.tile[num98, num100 - 1].TileType] || Main.tile[num98, num100 - 1].IsHalfBlock && (!Main.tile[num98, num100 - 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num98, num100 - 4].TileType] || Main.tileSolidTop[Main.tile[num98, num100 - 4].TileType])) && (!Main.tile[num98, num100 - 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num98, num100 - 2].TileType] || Main.tileSolidTop[Main.tile[num98, num100 - 2].TileType]) && (!Main.tile[num98, num100 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num98, num100 - 3].TileType] || Main.tileSolidTop[Main.tile[num98, num100 - 3].TileType]) && (!Main.tile[num98 - num97, num100 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num98 - num97, num100 - 3].TileType]))
                    {
                        float num101 = num100 * 16;
                        if (Main.tile[num98, num100].IsHalfBlock)
                        {
                            num101 += 8f;
                        }
                        if (Main.tile[num98, num100 - 1].IsHalfBlock)
                        {
                            num101 -= 8f;
                        }
                        if (num101 < vector30.Y + NPC.height)
                        {
                            float num102 = vector30.Y + NPC.height - num101;
                            float num103 = 16.1f;
                            if (num102 <= num103)
                            {
                                NPC.gfxOffY += NPC.position.Y + NPC.height - num101;
                                NPC.position.Y = num101 - NPC.height;
                                if (num102 < 9f)
                                {
                                    NPC.stepSpeed = 1f;
                                }
                                else
                                {
                                    NPC.stepSpeed = 2f;
                                }
                            }
                        }
                    }
                }
            }
            if (flag23)
            {
                int num104 = (int)((NPC.position.X + NPC.width / 2 + 15 * NPC.direction) / 16f);
                int num105 = (int)((NPC.position.Y + NPC.height - 15f) / 16f);
                if (Main.tile[num104, num105 - 1].HasUnactuatedTile && (TileLoader.IsClosedDoor(Main.tile[num104, num105 - 1]) || Main.tile[num104, num105 - 1].TileType == TileID.TallGateClosed) && flag26)
                {
                    NPC.ai[2] += 1f;
                    NPC.ai[3] = 0f;
                    if (NPC.ai[2] >= 60f)
                    {
                        bool flag16 = false;
                        bool flag17 = Main.player[NPC.target].ZoneGraveyard && Main.rand.Next(60) == 0;
                        if ((!Main.bloodMoon || Main.getGoodWorld) && !flag17 && flag16)
                        {
                            NPC.ai[1] = 0f;
                        }
                        NPC.velocity.X = 0.5f * -NPC.direction;
                        int num106 = 5;
                        if (Main.tile[num104, num105 - 1].TileType == TileID.TallGateClosed)
                        {
                            num106 = 2;
                        }
                        NPC.ai[1] += num106;
                        NPC.ai[2] = 0f;
                        bool flag18 = false;
                        if (NPC.ai[1] >= 10f)
                        {
                            flag18 = true;
                            NPC.ai[1] = 10f;
                        }
                        WorldGen.KillTile(num104, num105 - 1, fail: true);
                        if ((Main.netMode != NetmodeID.MultiplayerClient || !flag18) && flag18 && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            if (TileLoader.IsClosedDoor(Main.tile[num104, num105 - 1]))
                            {
                                bool flag19 = WorldGen.OpenDoor(num104, num105 - 1, NPC.direction);
                                if (!flag19)
                                {
                                    NPC.ai[3] = num154;
                                    NPC.netUpdate = true;
                                }
                                if (Main.netMode == NetmodeID.Server && flag19)
                                {
                                    NetMessage.SendData(MessageID.ToggleDoorState, -1, -1, null, 0, num104, num105 - 1, NPC.direction);
                                }
                            }
                            if (Main.tile[num104, num105 - 1].TileType == TileID.TallGateClosed)
                            {
                                bool flag20 = WorldGen.ShiftTallGate(num104, num105 - 1, closing: false);
                                if (!flag20)
                                {
                                    NPC.ai[3] = num154;
                                    NPC.netUpdate = true;
                                }
                                if (Main.netMode == NetmodeID.Server && flag20)
                                {
                                    NetMessage.SendData(MessageID.ToggleDoorState, -1, -1, null, 4, num104, num105 - 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    int num107 = NPC.spriteDirection;
                    if (NPC.velocity.X < 0f && num107 == -1 || NPC.velocity.X > 0f && num107 == 1)
                    {
                        if (NPC.height >= 32 && Main.tile[num104, num105 - 2].HasUnactuatedTile && Main.tileSolid[Main.tile[num104, num105 - 2].TileType])
                        {
                            if (Main.tile[num104, num105 - 3].HasUnactuatedTile && Main.tileSolid[Main.tile[num104, num105 - 3].TileType])
                            {
                                NPC.velocity.Y = -8f;
                                NPC.netUpdate = true;
                            }
                            else
                            {
                                NPC.velocity.Y = -7f;
                                NPC.netUpdate = true;
                            }
                        }
                        else if (Main.tile[num104, num105 - 1].HasUnactuatedTile && Main.tileSolid[Main.tile[num104, num105 - 1].TileType])
                        {
                            NPC.velocity.Y = -6f;
                            NPC.netUpdate = true;
                        }
                        else if (NPC.position.Y + NPC.height - num105 * 16 > 20f && Main.tile[num104, num105].HasUnactuatedTile && !Main.tile[num104, num105].TopSlope && Main.tileSolid[Main.tile[num104, num105].TileType])
                        {
                            NPC.velocity.Y = -5f;
                            NPC.netUpdate = true;
                        }
                        else if (NPC.directionY < 0 && (!Main.tile[num104, num105 + 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num104, num105 + 1].TileType]) && (!Main.tile[num104 + NPC.direction, num105 + 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num104 + NPC.direction, num105 + 1].TileType]))
                        {
                            NPC.velocity.Y = -8f;
                            NPC.velocity.X *= 1.5f;
                            NPC.netUpdate = true;
                        }
                        else if (flag26)
                        {
                            NPC.ai[1] = 0f;
                            NPC.ai[2] = 0f;
                        }
                        if (NPC.velocity.Y == 0f && flag24 && NPC.ai[3] == 1f)
                        {
                            NPC.velocity.Y = -5f;
                        }
                        if (NPC.velocity.Y == 0f && Main.expertMode && Main.player[NPC.target].Bottom.Y < NPC.Top.Y && Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) < Main.player[NPC.target].width * 3 && Collision.CanHit(NPC, Main.player[NPC.target]))
                        {
                            if (NPC.velocity.Y == 0f)
                            {
                                int num112 = 6;
                                if (Main.player[NPC.target].Bottom.Y > NPC.Top.Y - num112 * 16)
                                {
                                    NPC.velocity.Y = -7.9f;
                                }
                                else
                                {
                                    int num113 = (int)(NPC.Center.X / 16f);
                                    int num114 = (int)(NPC.Bottom.Y / 16f) - 1;
                                    for (int num115 = num114; num115 > num114 - num112; num115--)
                                    {
                                        if (Main.tile[num113, num115].HasUnactuatedTile && TileID.Sets.Platforms[Main.tile[num113, num115].TileType])
                                        {
                                            NPC.velocity.Y = -7.9f;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (flag26)
            {
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
            }
        }
        public override void OnKill()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
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
            npcLoot.Add(ItemDropRule.Common(ItemID.BandofRegeneration, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.ShoeSpikes, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Glowstick, 1, 40, 60));
            npcLoot.Add(ItemDropRule.Common(ItemID.LeadOre, 2, 6, 18));
            npcLoot.Add(ItemDropRule.Common(ItemID.LifeCrystal, 100, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.MiningPotion, 20, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.NightOwlPotion, 20, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.RopeCoil, 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.ShinePotion, 20, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.SpelunkerPotion, 40, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.ThrowingKnife, 2, 50, 250));
            npcLoot.Add(ItemDropRule.Common(ItemID.TinOre, 1, 3, 15));
            npcLoot.Add(ItemDropRule.Common(ItemID.TungstenOre, 2, 4, 20));
            npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumOre, 10, 4, 12));
            npcLoot.Add(ItemDropRule.Common(ItemID.Torch, 1, 20, 40));
        }
    }
}
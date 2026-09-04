using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonNPCGlobals;
using Xenon.Content.Biomes.Corrosion;

namespace Xenon.Content.NPCs.Bosses.StomachOfCthulhu
{
    //Totally not stolen hook code from Calamity Poltergeist

    public class StomachOfCthulhuHook : ModNPC
    {
        private int despawnTimer = 1000;
        private int parentID = XenonGlobalNPC.corrosionBoss;
        public static Asset<Texture2D> ChainTexture;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
            NPCID.Sets.TrailingMode[Type] = 1;
            if (!Main.dedServ)
            {
                ChainTexture = ModContent.Request<Texture2D>("Xenon/Content/NPCs/Bosses/StomachOfCthulhu/StomachOfCthulhuChain", AssetRequestMode.AsyncLoad);
            }
        }

        public static int ShotDamage = 55; // 220

        public override void SetDefaults()
        {
            NPC.damage = 0; // No contact damage
            NPC.aiStyle = -1;
            AIType = -1;
            NPC.width = 34;
            NPC.height = 24;
            NPC.lifeMax = 50000;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit34;
            NPC.DeathSound = SoundID.NPCDeath39;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(NPC.localAI[0]);
            writer.Write(NPC.localAI[1]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            NPC.localAI[0] = reader.ReadSingle();
            NPC.localAI[1] = reader.ReadSingle();
        }

        public override void AI()
        {
            // Despawn if SoC is gone
            if (parentID < 0 || !Main.npc[parentID].active)
            {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.active = false;
                NPC.netUpdate = true;
                return;
            }

            Player player = Main.player[Main.npc[parentID].target];

            Movement(player);
            
        }

        private void Movement(Player player)
        {

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (NPC.ai[0] == 0f)
                    NPC.ai[0] = (int)(NPC.Center.X / 16f);
                if (NPC.ai[1] == 0f)
                    NPC.ai[1] = (int)(NPC.Center.X / 16f);
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (NPC.ai[0] == 0f || NPC.ai[1] == 0f)
                    NPC.localAI[0] = 0f;

                else
                {
                    float shootBoost = 2f;
                    NPC.localAI[0] -= 1f + shootBoost;
                }

                if (NPC.localAI[0] <= 0f && NPC.ai[0] != 0f)
                {
                    foreach (var n in Main.ActiveNPCs)
                    {
                        if (n.whoAmI != NPC.whoAmI && n.type == NPC.type && (n.velocity.X != 0f || n.velocity.Y != 0f))
                            NPC.localAI[0] = 180f;
                    }
                }

                if (NPC.localAI[0] <= 0f)
                {
                    NPC.localAI[0] = 450f;
                    bool canMoveToTile = false;
                    int increment = 0;
                    while (!canMoveToTile && increment <= 1000)
                    {
                        increment++;
                        int playerTileX = (int)(player.Center.X / 16f);
                        int playerTileY = (int)(player.Center.Y / 16f);
                        if (NPC.ai[0] == 0f)
                        {
                            playerTileX = (int)((player.Center.X + Main.npc[parentID].Center.X) / 32f);
                            playerTileY = (int)((player.Center.Y + Main.npc[parentID].Center.Y) / 32f);
                        }
                        int randPlayerRadius = 20;
                        randPlayerRadius += (int)(100f * (increment / 1000f));
                        int randTileX = playerTileX + Main.rand.Next(-randPlayerRadius, randPlayerRadius + 1);
                        int randTileY = playerTileY + Main.rand.Next(-randPlayerRadius, randPlayerRadius + 1);
                        try
                        {
                            if (WorldGen.SolidTile(randTileX, randTileY) || Main.tile[randTileX, randTileY].WallType > WallID.None)
                            {
                                canMoveToTile = true;
                                NPC.ai[0] = randTileX;
                                NPC.ai[1] = randTileY;
                                NPC.localAI[1] = Vector2.Distance(NPC.Center, player.Center) * 0.01f;
                                NPC.netUpdate = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            if (NPC.ai[0] > 0f && NPC.ai[1] > 0f)
            {
                float velocityBoost = 2f;
                float velocity = 8f + velocityBoost;

                Vector2 hookCenter = new Vector2(NPC.Center.X, NPC.Center.Y);
                float hookXDest = NPC.ai[0] * 16f - 8f - hookCenter.X;
                float hookYDest = NPC.ai[1] * 16f - 8f - hookCenter.Y;
                float hookDestination = (float)Math.Sqrt(hookXDest * hookXDest + hookYDest * hookYDest);
                if (hookDestination < 12f + velocity)
                {
                    NPC.velocity.X = hookXDest;
                    NPC.velocity.Y = hookYDest;
                }
                else
                {
                    hookDestination = velocity / hookDestination;
                    NPC.velocity.X = hookXDest * hookDestination;
                    NPC.velocity.Y = hookYDest * hookDestination;
                }

                Vector2 hookCenterPassive = new Vector2(NPC.Center.X, NPC.Center.Y);
                float polterDirectionX = Main.npc[parentID].Center.X - hookCenterPassive.X;
                float polterDirectionY = Main.npc[parentID].Center.Y - hookCenterPassive.Y;
                NPC.rotation = (float)Math.Atan2(polterDirectionY, polterDirectionX) - 1.57f;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (parentID < 0 || !NPC.active || NPC.IsABestiaryIconDummy)
                return true;

            if (Main.npc[parentID].active)
            {
                Vector2 center = NPC.Center;
                float parentCenterX = Main.npc[parentID].Center.X - center.X;
                float parentCenterY = Main.npc[parentID].Center.Y - center.Y;
                float chainRotation = (float)Math.Atan2(parentCenterY, parentCenterX) - 1.57f;
                bool draw = true;
                while (draw)
                {
                    int chainWidth = 26;
                    int chainHeight = 18;
                    float parentDistance = (float)Math.Sqrt(parentCenterX * parentCenterX + parentCenterY * parentCenterY);
                    if (parentDistance < chainHeight)
                    {
                        chainWidth = (int)parentDistance - chainHeight + chainWidth;
                        draw = false;
                    }
                    parentDistance = chainWidth / parentDistance;
                    parentCenterX *= parentDistance;
                    parentCenterY *= parentDistance;
                    center.X += parentCenterX;
                    center.Y += parentCenterY;
                    parentCenterX = Main.npc[parentID].Center.X - center.X;
                    parentCenterY = Main.npc[parentID].Center.Y - center.Y;

                    Color color = Lighting.GetColor((int)(center.X / 16f), (int)(center.Y  / 16f));
                    Main.spriteBatch.Draw(ChainTexture.Value, new Vector2(center.X - screenPos.X, center.Y - screenPos.Y),
                        new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, ChainTexture.Value.Width, chainWidth)), color, chainRotation,
                        new Vector2(ChainTexture.Value.Width * 0.5f, ChainTexture.Value.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                }
            }

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (NPC.spriteDirection == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Texture2D texture2D15 = TextureAssets.Npc[Type].Value;
            Vector2 halfSizeTexture = new Vector2(TextureAssets.Npc[Type].Value.Width / 2, TextureAssets.Npc[Type].Value.Height / Main.npcFrameCount[Type] / 2);

            Vector2 drawLocation = NPC.Center - screenPos;
            drawLocation -= new Vector2(texture2D15.Width, texture2D15.Height / Main.npcFrameCount[Type]) * NPC.scale / 2f;
            drawLocation += halfSizeTexture * NPC.scale + new Vector2(0f, NPC.gfxOffY);
            spriteBatch.Draw(texture2D15, drawLocation, NPC.frame, NPC.GetAlpha(drawColor), NPC.rotation, halfSizeTexture, NPC.scale, spriteEffects, 0f);

            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.X == 0f && NPC.velocity.Y == 0f)
            {
                if (NPC.frame.Y < 1)
                {
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter > 4.0)
                    {
                        NPC.frameCounter = 0.0;
                        NPC.frame.Y = NPC.frame.Y + frameHeight;
                    }
                }
            }
            else if (NPC.frame.Y > 0)
            {
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter > 4.0)
                {
                    NPC.frameCounter = 0.0;
                    NPC.frame.Y = NPC.frame.Y - frameHeight;
                }
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.DungeonSpirit, hit.HitDirection, -1f, 0, default, 1f);
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.DungeonSpirit, hit.HitDirection, -1f, 0, default, 1f);
                }
            }
        }
    }
}
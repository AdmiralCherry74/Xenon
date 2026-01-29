using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Social.Base;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Content.NPCs.UndergroundMobs
{
    public class Sawblade : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlazingWheel];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 75;
            NPC.defense = 100;
            NPC.lifeMax = 100;
            NPC.dontTakeDamage = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 0;
            NPC.scale = 2;
            NPC.noGravity = true;

            AIType = NPCID.BoundGoblin;
            AnimationType = NPCID.BlazingWheel;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
            ]);
        }

        public override void AI()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
        }
        public override void OnSpawn(IEntitySource source)
        {
            NPC.position.Y += 32;
            Point tilePos = NPC.Center.ToTileCoordinates();
            if (!(Main.tile[tilePos.X - 1, tilePos.Y].HasTile && Main.tileSolid[Main.tile[tilePos.X - 1, tilePos.Y].TileType] &&
                Main.tile[tilePos.X + 1, tilePos.Y].HasTile && Main.tileSolid[Main.tile[tilePos.X + 1, tilePos.Y].TileType]))
            {
                NPC.active = false;
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
            SoundEngine.PlaySound(SoundID.Item22);
            if (Main.rand.NextBool(3) && Main.expertMode)
            {
                target.AddBuff(BuffID.Bleeding, 300);
                SoundEngine.PlaySound(SoundID.Item23);
            }
            else if (Main.rand.NextBool(3) && Main.masterMode)
            {
                target.AddBuff(BuffID.Bleeding, 600);
                SoundEngine.PlaySound(SoundID.Item23);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneRockLayerHeight)
            {
                return SpawnCondition.Cavern.Chance * 0.5f;
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
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
            }
        }
    }
}
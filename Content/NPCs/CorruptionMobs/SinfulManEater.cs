using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Banner;

namespace Xenon.Content.NPCs.CorruptionMobs
{
	public class SinfulManEater : ModNPC
	{
		private float PosX = 0f;
		private float PosY = 0f;
		private int timer = 0;
		private bool spawn = false;
		private static Asset<Texture2D> VineTexture;
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.ManEater];
			VineTexture = Mod.Assets.Request<Texture2D>("Content/NPCs/CorruptionMobs/SinfulManEater_Vine");

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
			NPC.damage = 25;
			NPC.defense = 1;
			NPC.lifeMax = 150;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 250;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = -1;
			AnimationType = NPCID.ManEater;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<StarvedManEaterBanner>();
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 v, Color drawColor)
		{
			//if (NPC.IsABestiaryIconDummy)
			//{
			//	Main.spriteBatch.Draw(bestiaryTexture.Value, NPC.Center - new Vector2(70f, -70f), new Rectangle(0, 0, bestiaryTexture.Value.Width, bestiaryTexture.Value.Height), Color.White, MathHelper.TwoPi / 8, new Vector2(bestiaryTexture.Value.Width / 2, bestiaryTexture.Value.Height), 1f, SpriteEffects.None, 1f);
			//	return false;
			//}
			Vector2 start = NPC.Center;
			Vector2 end = new Vector2(NPC.ai[1], NPC.ai[2]);
			start -= Main.screenPosition;
			end -= Main.screenPosition;
			Asset<Texture2D> TEX = VineTexture;
			int linklength = TEX.Value.Height;
			Vector2 chain = end - start;

			float length = (float)chain.Length();
			int numlinks = (int)Math.Ceiling(length / linklength);
			Vector2[] links = new Vector2[numlinks];
			float rotation = (float)Math.Atan2(chain.Y, chain.X);
			for (int i = 0; i < numlinks; i++)
			{
				links[i] = start + chain / numlinks * i;
				Main.spriteBatch.Draw(TEX.Value, links[i], new Rectangle(0, 0, TEX.Value.Width, linklength), Color.White, rotation + 1.57f, new Vector2(TEX.Value.Width / 2, TEX.Value.Height), 1f,
					SpriteEffects.None, 1f);
			}
			return true;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{

			bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.SinfulManEater")),
			]);
		}

		public override void AI()
		{
			timer++;
			NPC.TargetClosest(true);
			int i = (int)NPC.Center.X / 16;
			int j = (int)NPC.Center.Y / 16;
			while (j < Main.maxTilesY - 10 && Main.tile[i, j] != null && !WorldGen.SolidTile2(i, j) && Main.tile[i - 1, j] != null && !WorldGen.SolidTile2(i - 1, j) && Main.tile[i + 1, j] != null && !WorldGen.SolidTile2(i + 1, j))
				j += 2;
			int num = j - 1;
			float worldY = num * 16;
			if (!spawn)
			{
				spawn = true;
				NPC.position.Y = worldY;
				PosX = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f;
				PosY = Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f;
				NPC.ai[1] = NPC.position.X + NPC.width / 2;
				NPC.ai[2] = NPC.position.Y + NPC.height / 2;
			}

			if (timer > 180)
			{
				timer = 0;
				PosX = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f;
				PosY = Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f;
			}
			else if (timer > 110 || NPC.Distance(new Vector2(NPC.ai[1], NPC.ai[2])) > 450)
			{
				Vector2 vector8 = new Vector2(NPC.position.X + NPC.width * 0.5f - Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f, NPC.position.Y + NPC.height * 0.5f - Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f);
				PosX = NPC.ai[1] - vector8.X * 1f;
				PosY = NPC.ai[2] - vector8.Y * 1f;
			}
			if (PosX < NPC.position.X)
			{
				if (NPC.velocity.X > -4) { NPC.velocity.X -= 0.25f; }
			}
			else if (PosX > NPC.Center.X)
			{
				if (NPC.velocity.X < 4) { NPC.velocity.X += 0.25f; }
			}
			if (PosY < NPC.position.Y)
			{
				if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.25f;
			}
			else if (PosY > NPC.Center.Y)
			{
				if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.25f;
			}
			Vector2 vector6 = new Vector2(NPC.Center.X - NPC.ai[1], NPC.Center.Y - NPC.ai[1]);
			//NPC.rotation = ((float)Math.Atan2(Main.player[NPC.target].Center.Y - (double)NPC.Center.Y, Main.player[NPC.target].Center.X - (double)NPC.Center.X) + 3.14f) * 1f + ((float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X)) * 0.1f;
			NPC.rotation = NPC.Center.DirectionTo(Main.player[NPC.target].Center).ToRotation() + MathHelper.Pi;

			if (Main.rand.NextBool(15))
			{
				int num1225 = Dust.NewDust(NPC.Center + new Vector2(Main.rand.NextFloat(0, NPC.Center.Distance(new Vector2(NPC.ai[1], NPC.ai[2]))), 0).RotatedBy(NPC.Center.DirectionTo(new Vector2(NPC.ai[1], NPC.ai[2])).ToRotation()), (int)(NPC.width * 0.1f),
					(int)(NPC.height * 0.1f), DustID.HallowSpray, 0, 0, 150, NPC.color, 0.85f);
				Main.dust[num1225].noGravity = true;
				Main.dust[num1225].velocity *= 0.95f;
				int num1226 = Dust.NewDust(NPC.Center, NPC.width,
					(int)(NPC.height * 0.1f), DustID.HallowSpray, 0, 0, 150, NPC.color, 0.75f);
				Main.dust[num1226].noGravity = true;
				Main.dust[num1226].velocity *= 0.95f;
			}
			Lighting.AddLight(NPC.Center, 14f / 255f, 80f / 255f, 100f / 255f);
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
			if (spawnInfo.Player.ZoneCorrupt && spawnInfo.Player.ZoneJungle && spawnInfo.Player.ZoneDirtLayerHeight || spawnInfo.Player.ZoneCorrupt && spawnInfo.Player.ZoneJungle && spawnInfo.Player.ZoneRockLayerHeight)
			{
				return 0.5f;
			}   
			return 0;
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
            npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 3, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Vine, 2, 1, 1));
		}
	}
}
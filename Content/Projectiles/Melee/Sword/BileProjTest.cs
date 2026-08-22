using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Projectiles.Melee.Sword;

public class BileProjTest : ModProjectile
{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 3;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }
        public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;

            Projectile.penetrate = 1;
		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.damage = 10;
		Projectile.timeLeft = 1800;
		Projectile.aiStyle = ProjAIStyleID.Arrow;

		AIType = ProjectileID.WoodenArrowFriendly;
	}

	public override void AI() {
            
		// Apply gravity after a quarter of a second
		Projectile.ai[0] += 1f;
		if (Projectile.ai[0] >= 16) {
			Projectile.ai[0] = 16f;
			Projectile.velocity.Y += 0.50f;
        }

		// The projectile is rotated to face the direction of travel
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

		// Cap downward velocity
		if (Projectile.velocity.Y > 30f) {
			Projectile.velocity.Y = 30f;
		}
	}

	public override void OnKill(int timeLeft) {
		SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		for (int i = 0; i < 5; i++)
		{
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CorrosionWaterSplash>());
			dust.noGravity = true;
			dust.velocity *= 1.5f;
			dust.scale *= 0.9f;
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		for (int i = 0; i < 2; i++)
		{
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CorrosionWaterSplash>());
			dust.noGravity = true;
			dust.velocity *= 1.5f;
			dust.scale *= 0.9f;
		}
		target.AddBuff(BuffID.Slow, 300);
	}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
		for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CorrosionWaterSplash>());
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
            target.AddBuff(BuffID.Slow, 300);
        }

        public override bool PreDraw(ref Color lightColor) {
		// Draws an afterimage trail. See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#afterimage-trail for more information.

		Texture2D texture = TextureAssets.Projectile[Type].Value;

		Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
		for (int k = Projectile.oldPos.Length - 1; k > 0; k--) {
			Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
			Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		}

		return true;
	}
}	
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Magic.SpellBookProj
{
	// Thorn Projectiles, sampled off of the example arrow.
	public class ThornStormProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Type] = 0; // The recording mode
		}

		public override void SetDefaults() {
			Projectile.width = 10; // The width of projectile hitbox
			Projectile.height = 10; // The height of projectile hitbox

            Projectile.penetrate = 4;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 1800;
			Projectile.aiStyle = ProjAIStyleID.Arrow;

			AIType = ProjectileID.WoodenArrowFriendly;
		}

		public override void AI() {
            
			// Apply gravity after a quarter of a second
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 15f) {
				Projectile.ai[0] = 15f;
				Projectile.velocity.Y += 0.1f;
			}

			// The projectile is rotated to face the direction of travel
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

			// Cap downward velocity
			if (Projectile.velocity.Y > 16f) {
				Projectile.velocity.Y = 16f;
			}
		}

		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
			for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.velocity *= 1.5f;
				dust.scale *= 0.9f;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			for (int i = 0; i < 2; i++) // Creates a splash of dust around the position the projectile dies.
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.velocity *= 1.5f;
				dust.scale *= 0.9f;
			}
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
}
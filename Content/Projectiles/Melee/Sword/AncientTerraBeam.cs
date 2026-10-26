using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Melee.Sword
{
    public class AncientTerraBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = -1;
			Projectile.alpha = 255;
        }
		public override void AI()
		{
			if (Projectile.localAI[1] > 4f)
			{
				Vector2 pos = Projectile.position + new Vector2(2);
				int num447 = Dust.NewDust(pos, 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f);
				Main.dust[num447].velocity *= -0.25f;
				num447 = Dust.NewDust(pos, 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f);
				Main.dust[num447].velocity *= -0.25f;
				Main.dust[num447].position -= Projectile.velocity * 0.5f;
			}

			if (Projectile.localAI[1] < 15)
			{
				Projectile.localAI[1]++;
			}
			else if (Projectile.localAI[0] == 0)
			{
				Projectile.scale -= 0.02f;
				Projectile.alpha += 30;
				if (Projectile.alpha >= 250)
				{
					Projectile.alpha = 255;
					Projectile.localAI[0] = 1;
				}
			}
			else if (Projectile.localAI[0] == 1)
			{
				Projectile.scale += 0.02f;
				Projectile.alpha -= 30;
				if (Projectile.alpha <= 0)
				{
					Projectile.alpha = 0;
					Projectile.localAI[0] = 0;
				}
			}
			if (Projectile.ai[1] == 0f)
			{
				Projectile.ai[1] = 1f;
				SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
			}
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 0.785f;
			if (Projectile.velocity.Y > 16)
			{
				Projectile.velocity.Y = 16;
			}
		}
		public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 15; i++)
            {
				Vector2 pos = Projectile.position + Vector2.Normalize(Projectile.oldVelocity) * Utils.Remap(i, 0, 15, -60, 30);
                Dust d = Dust.NewDustDirect(pos, Projectile.width, Projectile.height, DustID.Terra);
                d.noGravity = true;
                d.scale += Main.rand.NextFloat();
                d.velocity *= 0.3f;
                d.velocity += Projectile.oldVelocity * Main.rand.NextFloat(0.3f);

                Dust d2 = Dust.NewDustDirect(pos, Projectile.width, Projectile.height, DustID.Terra);
				d2.velocity *= 0.2f;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
			var tex = TextureAssets.Projectile[Type].Value;
			Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, null, new Color(Projectile.Opacity, Projectile.Opacity, Projectile.Opacity,0), Projectile.rotation, new Vector2(10,30), Projectile.scale, SpriteEffects.None);
			return false;
        }
    }
}
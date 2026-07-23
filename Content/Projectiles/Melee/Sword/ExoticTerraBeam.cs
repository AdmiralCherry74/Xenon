using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Melee.Sword
{
    public class ExoticTerraBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.damage = 1000000;
			Projectile.timeLeft = 1000000000;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = -1;
        }
		public override void AI()
		{
			if (Projectile.localAI[1] > 7f)
			{
				int num447 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f);
				Main.dust[num447].velocity *= -0.25f;
				num447 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Terra, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f);
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
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Terra);
                dust.noGravity = true;
                dust.velocity *= 1;
                dust.scale *= 1f;
            }
        }
    }
}
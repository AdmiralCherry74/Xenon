using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Magic.SplashPotionProj.PositiveEffectsProj
{
    public class HunterSplashPotionProj : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 1200;
        }

        public override void AI()
        {

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y += 0.3f;
            }

            //Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;


            if (Projectile.velocity.Y > 32f)
            {
                Projectile.velocity.Y = 32f;
            }
        }
        public override void PostAI()
        {
            Dust d = Dust.NewDustDirect(Projectile.Center + new Vector2(0, -3), 0, 0, DustID.Pumpkin, default, 1);
            d.noGravity = true;
            d.fadeIn = 1f;
            d.velocity *= 0.25f;
            d.velocity += Projectile.velocity * 0.25f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Pumpkin, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Hunter, 14400);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Pumpkin, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Hunter, 14400);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Pumpkin);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
    }
}
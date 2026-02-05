using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Traps
{
    public class QuicksandBall : ModProjectile //fired from the Sandball Trap
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.maxPenetrate = 1;
            Projectile.hostile = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 1200;
        }

        public override void AI()
        {

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 60f)
            {
                Projectile.ai[0] = 60f;
                Projectile.velocity.Y += 0.2f;
            }

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void PostAI()
        {
            Dust d = Dust.NewDustDirect(Projectile.Center + new Vector2(0, -3), 0, 0, DustID.Sand, default, 1);
            d.noGravity = true;
            d.fadeIn = 1f;
            d.velocity *= 0.25f;
            d.velocity += Projectile.velocity * 0.25f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }

            if (!Main.expertMode && !Main.masterMode) //classic
            {
                target.AddBuff(BuffID.Darkness, 60);
            }
            if (Main.expertMode && !Main.masterMode) //expert
            {
                target.AddBuff(BuffID.Darkness, 180);
            }
            if (!Main.expertMode && Main.masterMode) //master
            {
                target.AddBuff(BuffID.Darkness, 360);
            }
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Sand);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.5f;
            }
        }
    }
}
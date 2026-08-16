using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonProjectileGlobals;

namespace Xenon.Content.Projectiles.Magic.SplashPotionProj.PositiveEffectsProj
{
    public class CalmingSplashPotionProj : SplashPotionProjs
    {
        public override void PostAI()
        {
            Dust d = Dust.NewDustDirect(Projectile.Center + new Vector2(0, -3), 0, 0, DustID.DungeonWater, default, 1);
            d.noGravity = true;
            d.fadeIn = 1f;
            d.velocity *= 0.25f;
            d.velocity += Projectile.velocity * 0.25f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonWater, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Calm, 2592000);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonWater, default, 1);
                d.noGravity = true;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Calm, 2592000);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonWater);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
    }
}
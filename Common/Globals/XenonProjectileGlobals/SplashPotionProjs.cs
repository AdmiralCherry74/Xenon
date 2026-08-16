using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Common.Globals.XenonProjectileGlobals
{
    public class SplashPotionProjs : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 1200;
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
        }

        public override void AI()
        {

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y += 0.2f;
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;


            if (Projectile.velocity.Y > 32f)
            {
                Projectile.velocity.Y = 32f;
            }
        }
    }
}

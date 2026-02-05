using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Projectiles.Magic.StaveProj
{
    public class GarnetGemball : ModProjectile
    {
        private static int dustId = ModContent.DustType<GarnetGemDust>();
        private static Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(112, 224, 149) * 0.7f;
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
        }

        public override void AI()
        {
            for (var i = 0; i < 2; i++)
            {
                var dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustId, Projectile.velocity.X, Projectile.velocity.Y, 50, default, 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
            }
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }

            Lighting.AddLight(new Vector2((int)((Projectile.position.X + (float)(Projectile.width / 2)) / 16f), (int)((Projectile.position.Y + (float)(Projectile.height / 2)) / 16f)), color.ToVector3());
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int num453 = 0; num453 < 15; num453++)
            {
                int num454 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustId, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 50, default, 1.2f);
                Main.dust[num454].noGravity = true;
                Dust dust152 = Main.dust[num454];
                Dust dust226 = dust152;
                dust226.scale *= 1.25f;
                dust152 = Main.dust[num454];
                dust226 = dust152;
                dust226.velocity *= 0.5f;
            }
        }
    }
}
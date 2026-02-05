using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Magic.MagicGunProj
{
    // This projectile demonstrates exploding tiles (like a bomb or dynamite), spawning child projectiles, and explosive visual effects.
    public class RayExplosion : ModProjectile
    {
        private const int DefaultWidthHeight = 15;
        private const int ExplosionWidthHeight = 250;

        private bool IsChild
        {
            get => Projectile.localAI[0] == 1;
            set => Projectile.localAI[0] = value.ToInt();
        }

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.

            // This set handles some things for us already:
            // Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
            // Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            // While the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            Projectile.width = DefaultWidthHeight;
            Projectile.height = DefaultWidthHeight;
            Projectile.friendly = true;
            Projectile.penetrate = 0;

            // These help the projectile hitbox be centered on the projectile sprite.
            DrawOffsetX = -2;
            DrawOriginOffsetY = -5;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.position.X = Projectile.position.X - Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
            for (int num341 = 0; num341 < 30; num341++)
            {
                int num342 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                Main.dust[num342].velocity *= 1.4f;
            }
            for (int num343 = 0; num343 < 20; num343++)
            {
                int num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 3.5f);
                Main.dust[num344].noGravity = true;
                Main.dust[num344].velocity *= 7f;
                num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GreenTorch, 0f, 0f, 100, default, 1.5f);
                Main.dust[num344].velocity *= 3f;
            }
            for (int num345 = 0; num345 < 2; num345++)
            {
                float scaleFactor8 = 0.4f;
                if (num345 == 1)
                {
                    scaleFactor8 = 0.8f;
                }
                int num346 = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), default, Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Main.gore[num346].velocity.X++;
                Main.gore[num346].velocity.Y++;
                num346 = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), default, Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Main.gore[num346].velocity.X--;
                Main.gore[num346].velocity.Y++;
                num346 = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), default, Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Main.gore[num346].velocity.X++;
                Main.gore[num346].velocity.Y--;
                num346 = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y), default, Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Main.gore[num346].velocity.X--;
                Main.gore[num346].velocity.Y--;
            }
        }
    }
}
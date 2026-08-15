
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Projectiles.Boss.StomachOfCthulhu
{
    public class StomachBubble : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.alpha = 75;
            Projectile.aiStyle = 1;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 1;
        }
        public override void AI() => Lighting.AddLight(Projectile.Center, Color.YellowGreen.ToVector3() * 0.78f);

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 50; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(2f, 2f);
                Dust StomachBubbleLight = Dust.NewDustPerfect(Projectile.Center, DustID.CursedTorch, speed * 5, Scale: 1.5f);
                Dust StomachBubbleWater = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<StomachOfCthulhusWaterSplash>(), speed * 3, Scale: 1.25f);
                StomachBubbleLight.noGravity = true;
            }
            SoundEngine.PlaySound(in SoundID.Item54, Projectile.Center);
        }
    }
}

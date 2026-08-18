using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;
using Xenon.Content.WorldGeneration.Helpers;

namespace Xenon.Content.Projectiles.Tools.ConvertingTools.ThrowingWater
{
    public class UrinalWaterProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
        }
        public override void OnKill(int timeLeft)
        {
            Point p = Projectile.Center.ToTileCoordinates();
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            for (int num996 = 0; num996 < 5; num996++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Glass);
            }
            for (int num997 = 0; num997 < 30; num997++)
            {
                int num999 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<UrinalWaterDust>(), 0f, -2f, 0, default(Color), 1.1f);
                Main.dust[num999].alpha = 100;
                Main.dust[num999].velocity.X *= 1.5f;
                Dust dust92 = Main.dust[num999];
                Dust dust334 = dust92;
                dust334.velocity *= 3f;
            }
            ConversionHelper.ConvertToCorrosion(p.X, p.Y, 4);
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
    }
}


using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Projectiles.Boss.StomachOfCthulhu
{
    public class DimitriTreatmentProj : ModProjectile
    {
        //This is a reference to a Call Of Duty: Black Ops campaign mission where a character gets gassed by Nova 6
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.alpha = 125;
            Projectile.aiStyle = 1;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1800;
            Projectile.ignoreWater = false;
        }
        public override void AI() => Lighting.AddLight(Projectile.Center, Color.YellowGreen.ToVector3() * 0.38f);

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(in SoundID.NPCDeath6, Projectile.Center);
        }
    }
}

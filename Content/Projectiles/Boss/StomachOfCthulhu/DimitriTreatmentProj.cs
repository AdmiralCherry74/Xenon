
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
        int groundtimeleft = 600;
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
        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, Color.Green.ToVector3() * 0.78f);

            Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            if (Projectile.ai[0] >= 150f)
            {
                Projectile.ai[0] = 150f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            }
            if (Projectile.velocity.Y > 4f)
            {
                Projectile.velocity.Y = 4f;
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Main.masterMode)
            {
                target.AddBuff(BuffID.Poisoned, 300 * 3);
            }
            else if (Main.expertMode && !Main.masterMode)
            {
                target.AddBuff(BuffID.Poisoned, 300 * 2);
            }
            else if (!Main.expertMode)
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
            Projectile.timeLeft -= 1200;
            Projectile.damage = 10;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            groundtimeleft--;

            if (groundtimeleft == 0)
            {
                Projectile.timeLeft = 0;
            }
            return false;
        }
    }
}

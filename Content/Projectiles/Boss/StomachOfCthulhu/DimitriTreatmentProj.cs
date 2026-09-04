
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
        bool landed = false;
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
            Projectile.shouldFallThrough = false;
        }
        public override void AI()
        {
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

            if (Main.rand.Next(4) < 3) {
                int dust = Dust.NewDust(Projectile.position - new Vector2(2f, 2f), Projectile.width + 4, Projectile.height + 4, DustID.CursedTorch, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4)) {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
			}
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            if(landed)
            {
                fallThrough = false;
            }
            else
            {
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    Player player = Main.player[i];
                    if (player.active && !player.dead && !player.ghost && player.Top.Y <= Projectile.Center.Y && player.Distance(Projectile.Center) < 1500)
                    {
                        fallThrough = false;
                        landed = true;
                        break;
                    }
                }
            }
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
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

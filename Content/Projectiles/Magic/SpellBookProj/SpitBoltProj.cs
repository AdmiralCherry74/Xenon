using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Magic.SpellBookProj
{
    public class SpitBoltProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8; 
            Projectile.height = 8;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            AIType = ProjectileID.Bullet;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.damage = 10;
            Projectile.penetrate = 3; 
            Projectile.timeLeft = 1800; 
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.alpha = 255 / 2;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned, 0f, 0f, 100, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, 0f, 0f, 100, default, 0.75f);
                dust.velocity *= 0.55f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned, default, 1f);
                d.noGravity = false;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Poisoned, 300);
        }
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned, default, 1);
                d.noGravity = false;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.Poisoned, 300);
        }
        public override void AI()
        {
            for (int i = 0; i < 2; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned, default, 1f);
                d.noGravity = false;
                d.fadeIn = 1.1f;
                d.position = Projectile.Center * Main.rand.Next(4);

                Dust db = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, default, 0.75f);
                db.noGravity = false;
                db.fadeIn = 1.1f;
                db.position = Projectile.Center * Main.rand.Next(4);
            }
        }
    }
}
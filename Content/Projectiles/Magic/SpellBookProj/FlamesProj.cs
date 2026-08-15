using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Data;

namespace Xenon.Content.Projectiles.Magic.SpellBookProj
{
    public class FlamesProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileSets.FireElementProjectile[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8; 
            Projectile.height = 8;
            Projectile.aiStyle = ProjAIStyleID.Flamethrower;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.damage = 10;
            Projectile.penetrate = -1; 
            Projectile.timeLeft = 150; 
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.alpha = 0;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, default, 1f);
                d.noGravity = false;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.OnFire, 150);
        }
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, default, 1);
                d.noGravity = false;
                d.fadeIn = 1.3f;
            }
            target.AddBuff(BuffID.OnFire, 150);
        }
        public override void AI()
        {
            if (Projectile.wet || Projectile.lavaWet || Projectile.honeyWet || Projectile.shimmerWet)
            {
                Projectile.timeLeft = 0;
                Projectile.damage = 0;
                Projectile.knockBack = 0;
            }
            else
            {
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] > 10f)
                {
                    Projectile.ai[0] = 10f;
                    if (Projectile.velocity.X != 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.96f;

                        if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01)
                        {
                            Projectile.velocity.X = 0f;
                            Projectile.netUpdate = true;
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, default, 1f);
                    d.noGravity = false;
                    d.fadeIn = 1.1f;
                    d.position = Projectile.Center * Main.rand.Next(10);

                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Projectiles.Summoner.Caltrops;

public class IronCaltropsProj : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 18; // The width of projectile hitbox
        Projectile.height = 15; // The height of projectile hitbox
        Projectile.scale = 0.20f;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 2700; // The live time for the projectile (60 = 1 second, so its X seconds times 60)
        Projectile.ignoreWater = false;
        Projectile.tileCollide = true;
        Projectile.usesLocalNPCImmunity = true;

        AIType = ProjectileID.SpikyBall; // Act exactly like Spiky Ball
    }
    public override void AI()
    {

        float angularVelocity = Projectile.velocity.Length();
        if (angularVelocity < 0.55)
        {
            angularVelocity = 0;
        }
        Projectile.rotation += angularVelocity * Projectile.direction;
        Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
        if (Projectile.ai[0] >= 15f)
        {
            Projectile.ai[0] = 15f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        if (Projectile.velocity.Y > 32f)
        {
            Projectile.velocity.Y = 32f;
        }
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.Confused, 20);
        target.AddBuff(ModContent.BuffType<IronCaltropTagDamage>(), 16);
        Projectile.localNPCHitCooldown = -1; // 1 hit per npc max
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.penetrate--;
        if (Projectile.penetrate <= -1)
        {
            Projectile.ai[0] += 0.1f;
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            Projectile.velocity *= 0.50f;

        }
        return false;
    }
}
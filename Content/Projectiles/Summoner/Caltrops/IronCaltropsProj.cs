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
        Projectile.width = Projectile.height = 18;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 60 * 8;
        Projectile.ignoreWater = false;
        Projectile.tileCollide = true;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = -1;
        Projectile.aiStyle = -1;
    }
    public override void AI()
    {

        Projectile.rotation += Projectile.velocity.X * 0.1f;
        Projectile.ai[0]++;
        if (Projectile.ai[0] >= 15f)
        {
            Projectile.ai[0] = 15f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        if (Projectile.velocity.Y > 32f)
        {
            Projectile.velocity.Y = 32f;
        }
        if(Projectile.timeLeft < 20)
        {
            Projectile.Opacity -= 1 / 20f;
        }
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.Confused, 20);
        target.AddBuff(ModContent.BuffType<IronCaltropTagDamage>(), 16);
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if(Projectile.velocity.X != Projectile.oldVelocity.X)
        {
            Projectile.velocity.X = -Projectile.oldVelocity.X * 0.5f;
        }
        if (Projectile.velocity.Y != Projectile.oldVelocity.Y)
        {
            Projectile.velocity.Y = -Projectile.oldVelocity.Y * 0.5f;
            Projectile.velocity.X *= 0.9f;
        }
        return false;
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Pets;

public class GraveBuster : ModProjectile
{
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 6;
        Main.projPet[Projectile.type] = true;
    }

    public override void SetDefaults()
    {
        Projectile.netImportant = true;
        Projectile.width = 30;
        Projectile.height = 30;
        Projectile.aiStyle = -1;
        Projectile.penetrate = -1;
        Projectile.timeLeft *= 5;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.friendly = true;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }
    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        // If the player is no longer active (online) - deactivate (remove) the projectile.
        if (!player.active)
        {
            Projectile.active = false;
            return;
        }

        // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
        if (!player.dead && player.HasBuff(ModContent.BuffType<Buffs.Pets.GraveBuster>()))
        {
            Projectile.timeLeft = 2;
        }

        Vector2 targetPos = player.Center + new Vector2(0, Projectile.ai[0] - 40) + new Vector2(player.velocity.X, player.velocity.Y);
        int ForcedMovementSpeed = 3;
        if (player.controlUp)
        {
            Projectile.ai[0] -= ForcedMovementSpeed;
        }
        else if (player.controlDown)
        {
            Projectile.ai[0] += ForcedMovementSpeed;
        }

        if (player.controlUp || player.controlDown)
        {
            Projectile.Center = Vector2.SmoothStep(Projectile.Center, targetPos, 0.1f);
        }

        Projectile.ai[0] = MathHelper.Clamp(Projectile.ai[0], -40, 40 * 3);
        Projectile.velocity = Vector2.SmoothStep(Projectile.velocity += Projectile.Center.DirectionTo(targetPos) * (Projectile.Center.Distance(targetPos) * 0.01f), Projectile.Center.DirectionTo(targetPos) * 3, 0.1f);
        if (Projectile.Center.Distance(targetPos) < 10)
        {
            Projectile.velocity *= 0.8f;
        }
        if (Projectile.Center.Distance(targetPos) < 3 && Projectile.velocity.Length() < 1)
        {
            Projectile.velocity *= 0f;
        }
        float MaxSpeed = MathHelper.Clamp(Projectile.Center.Distance(targetPos) * 0.05f, 6, 12);
        Projectile.velocity = Vector2.Clamp(Projectile.velocity, new Vector2(-MaxSpeed), new Vector2(MaxSpeed));

        if (!player.controlDown && !player.controlUp && Projectile.Center.Distance(targetPos) < 100)
        {
            Projectile.velocity *= 0.95f;
        }

        if (Projectile.Center.Distance(player.Center) > 1000)
            Projectile.Center = player.Center;

        Projectile.rotation = Projectile.velocity.X * 0.06f;
    }
}
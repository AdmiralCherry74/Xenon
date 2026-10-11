using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Tools.Glowsticks;

public class ImpactGlowstickProj : ModProjectile
{
    public int IShouldBeGlowing;

    public override void SetDefaults()
    {
        Projectile.width = 6;
        Projectile.height = 6;
        Projectile.alpha = 75;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 18000;
        Projectile.aiStyle = ProjAIStyleID.GroundProjectile;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        //this code makes it so the 'Impact' part of the glowstick actually works. it glows brighter when running into walls. and when it lasts long enough, itll glow brighter no matter what on next collision
        if (Math.Abs(oldVelocity.Y) >= 8 || (Projectile.velocity.X == 0 && oldVelocity.X != 0))
        {
            IShouldBeGlowing++;
        }
        return false;
    }


    public override void AI()
    {
        Vector2 position = Projectile.Center;

        if (IShouldBeGlowing > 0)
        {
            Lighting.AddLight(position, 1.75f, 1.75f, 1.75f);
        }
        else
        {
            Lighting.AddLight(position, 1f, 1f, 1f);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles;

public class SewerFuryBall : ModProjectile
{
    public override void SetStaticDefaults()
    {
        Main.projFrames[Type] = 1;
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 29;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
    }
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.Flamelash);
        Projectile.width = 10;
        Projectile.height = 10;
        Projectile.friendly = true;
        Projectile.light = 0.8f;
        Projectile.DamageType = DamageClass.Magic;
        DrawOriginOffsetY = -6;
        Projectile.extraUpdates = 1;
        Projectile.penetrate = 1;
    }
}
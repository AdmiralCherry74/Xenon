using System;
using System.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Ranged.Flames
{
    public class XenonFlames : ModProjectile
    {
        public override string Texture => "Terraria/Images/Projectile_85";
        public override void SetDefaults()
        {
            Projectile.width = 98;
            Projectile.height = 98;
            
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;

            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = ProjAIStyleID.Flamethrower;
            AIType = ProjectileID.Flames;
        }

        //This doesn't work rn
    }
}
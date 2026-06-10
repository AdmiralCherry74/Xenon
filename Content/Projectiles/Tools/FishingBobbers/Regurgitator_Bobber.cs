using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Tools.FishingBobbers
{
    public class Regurgitator_Bobber : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BobberWooden);
            DrawOriginOffsetY = -8; // Adjusts the draw position
        }
    }
}

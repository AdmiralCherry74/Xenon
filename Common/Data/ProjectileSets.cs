using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Magic.SpellBookProj;

namespace Xenon.Common.Data
{
    [ReinitializeDuringResizeArrays]
    public static class ProjectileSets
    {
        //Just so everyone knows. these will be catagorized like how they are in skylanders
        #region Elements
        public static readonly bool[] FireElementProjectile = ProjectileID.Sets.Factory.CreateBoolSet(
        #region Vanila Projectiles
            ProjectileID.FlamingArrow,
            ProjectileID.FlamethrowerTrap,
            ProjectileID.FlamesTrap,
            ProjectileID.Fireball,
            ProjectileID.InfernoHostileBlast,
            ProjectileID.InfernoHostileBolt,
            ProjectileID.GreekFire1,
            ProjectileID.GreekFire2,
            ProjectileID.GreekFire3,
            ProjectileID.CultistBossFireBall,
            ProjectileID.GeyserTrap,
            ProjectileID.DD2BetsyFireball,
            ProjectileID.DD2BetsyFlameBreath,
            ProjectileID.TorchGod);
        #endregion
        #endregion
    }
}
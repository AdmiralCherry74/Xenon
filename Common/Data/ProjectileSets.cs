using Terraria.ID;

namespace Xenon.Common.Data
{
    public static class ProjectileSets
    {
        public static readonly bool[] ProjFireDamage = NPCID.Sets.Factory.CreateBoolSet(
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

        //theres no modded fire projectiles so we skip these :)
    }
}
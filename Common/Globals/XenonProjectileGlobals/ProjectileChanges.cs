using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff;

namespace Xenon.Common.Globals.XenonProjectileGlobals
{
    public class ProjectileChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile entity)
        {
            if (entity.type == ProjectileID.Rally)
            {
                entity.damage = 18;
            }
        }
        public override void OnHitNPC(Projectile entity, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (entity.type == ProjectileID.Rally)
            {
                target.AddBuff(ModContent.BuffType<WeakestWeaponDefensivePierce>(), 150);
            }
        }
    }
}

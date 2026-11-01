using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Minions;

namespace Xenon.Content.Projectiles.Summoner.Minions
{
    public class BunnyMinionTinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 12;
            ProjectileID.Sets.MinionTargettingFeature[Type] = true;

            Main.projPet[Type] = true;

            ProjectileID.Sets.MinionSacrificable[Type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 26;
            Projectile.tileCollide = true; 

            Projectile.friendly = true;
            Projectile.minion = true; 
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
            Projectile.minionPos = 0;
            Projectile.tileCollide = true;
            Projectile.aiStyle = ProjAIStyleID.CommonFollow;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;

            AIType = ProjectileID.FlinxMinion;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {

            Player owner = Main.player[Projectile.owner];

            if (!CheckActive(owner))
            {
                return;
            }
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<BunnyMinionBuff>());

                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<BunnyMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }
    }
}
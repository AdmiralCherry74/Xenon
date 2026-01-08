using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Minions;

namespace Xenon.Content.Projectiles.Summoner.Minions
{
    // This minion shows a few mandatory things that make it behave properly.
    // Its attack pattern is simple: If an enemy is in range of 43 tiles, it will fly to it and deal contact damage
    // If the player targets a certain NPC with right-click, it will fly through tiles to it
    // If it isn't attacking, it will float near the player with minimal movement
    public class BunnyMinionProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 12;
            ProjectileID.Sets.MinionTargettingFeature[Type] = true;

            Main.projPet[Type] = true; // Denotes that this projectile is a pet or minion

            ProjectileID.Sets.MinionSacrificable[Type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.CultistIsResistantTo[Type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 26;
            Projectile.tileCollide = true; // Makes the minion not go through tiles freely

            // These below are needed for a minion weapon
            Projectile.friendly = true;
            Projectile.minion = true; // Declares this as a minion (has many effects)
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
            Projectile.minionPos = 0;
            Projectile.tileCollide = true;
            Projectile.aiStyle = ProjAIStyleID.CommonFollow;

            AIType = ProjectileID.FlinxMinion; // Act exactly like Soulscourge pirate
        }

        // Here you can decide if your minion breaks things like grass or pots
        public override bool? CanCutTiles()
        {
            return false;
        }

        // This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
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

        // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
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
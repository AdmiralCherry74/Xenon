using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Projectiles.Melee.Sword
{
    public class AncientTerraBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 40;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 10000;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = ProjAIStyleID.Beam;
            SoundEngine.PlaySound(SoundID.Item8, Projectile.position);

            AIType = ProjectileID.SwordBeam;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Terra);
                dust.noGravity = true;
                dust.velocity *= 1;
                dust.scale *= 1f;
            }
        }
    }
}
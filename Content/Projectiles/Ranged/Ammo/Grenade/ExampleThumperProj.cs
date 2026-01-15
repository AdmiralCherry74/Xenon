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

namespace Xenon.Content.Projectiles.Ranged.Ammo.Grenade
{
    public class ExampleThumperProj : ModProjectile
    {
        public int DefaultWidthHeight { get; private set; }
        public int ExplosionWidthHeight { get; private set; }

        //Selene here. This was adapted from Example mods arrow. i kept some of the comments so I can remember what is doing what.
        //Every thumper will use this Example Bolt as a way to have crossbow's use any type of Greande thumper.
        //remove comments when making a proper thumper!
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsARocketThatDealsDoubleDamageToPrimaryEnemy[Type] = true; // Deals double damage on direct hits.
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.
            ProjectileID.Sets.Explosive[Type] = true;
            // This set handles some things for us already:
            // Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
            // Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
        }

        public override void SetDefaults()
        {
            Projectile.width = DefaultWidthHeight;
            Projectile.height = DefaultWidthHeight;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.timeLeft = 500;
            Projectile.aiStyle = ProjAIStyleID.Explosive;

            AIType = ProjectileID.GrenadeI;
            DrawOffsetX = -5;
            DrawOriginOffsetY = 0;
        }

        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow(); // Get ready to explode.
            }
            else
            {
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= 5f)
                {
                    Projectile.ai[0] = 5f;
                    Projectile.velocity.Y += 0.2f;
                }

                // The projectile is rotated to face the direction of travel
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

                // Cap downward velocity
                if (Projectile.velocity.Y > 32f)
                {
                    Projectile.velocity.Y = 32f;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.timeLeft = 0;
            Projectile.PrepareBombToBlow();
            return true;
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; // This is important or the explosion will be in the wrong place if the bomb explodes on slopes.
            Projectile.alpha = 255; // Set to transparent. This projectile technically lives as transparent for about 3 frames

            // Change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
            Projectile.Resize(ExplosionWidthHeight, ExplosionWidthHeight);

            Projectile.damage = 40; // Bomb: 100, Dynamite: 250
            Projectile.knockBack = 8f; // Bomb: 8f, Dynamite: 10f
        }

        public override void OnKill(int timeLeft)
        {
            // Play explosion sound
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            // Smoke Dust spawn
            for (int i = 0; i < 50; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.4f;
            }

            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 3f);
                dust.noGravity = true;
                dust.velocity *= 5f;
                dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.velocity *= 3f;
            }

            // Large Smoke Gore spawn
            for (int g = 0; g < 2; g++)
            {
                var goreSpawnPosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f);
                Gore gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y -= 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y -= 1.5f;
            }
            // reset size to normal width and height.
            Projectile.Resize(DefaultWidthHeight, DefaultWidthHeight);
            DrawOffsetX = -5;
            DrawOriginOffsetY = 0;
        }
    }
}
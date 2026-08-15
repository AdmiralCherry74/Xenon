using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Ranged.Arms;

public class M1Garand : ModItem
{

    private int shots = 0;

    public override void SetDefaults()
    {
        Item.width = 82;
        Item.height = 20;
        Item.scale = 1f;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = ItemRarityID.Lime;

        Item.damage = 75;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.knockBack = 4.5f;
        Item.autoReuse = false;

        Item.value = 700000;
        Item.UseSound = SoundID.Item11; // Gun use sound

        Item.noMelee = true;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 20f; // Speed of a projectile. Mainly measured by eye
        Item.useAmmo = AmmoID.Bullet; // What ammo gun uses
    }

    public override bool CanConsumeAmmo(Item ammo, Player player) => Main.rand.Next(101) <= 10; // Chance in % to not consume ammo

    public override Vector2? HoldoutOffset() => new Vector2(-10f, 0f); // Offset in pixels at which the player will hold the gun. -Y is up

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (type == ProjectileID.Bullet)
        {
            type = ProjectileID.ExplosiveBullet;
        }

        if (shots == 7)
        {
            shots = 0;

            SoundEngine.PlaySound(new SoundStyle("TheAutumn/Assets/Sounds/Items/M1GarandClipEjection"));

            for (int i = 0; i < 5; i++)
            {
                // New velocity for new bullets
                Vector2 NewVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                // Some random to bullet speed
                NewVelocity *= 1f - Main.rand.NextFloat(0.2f);

                // Creating new projectile
                Projectile.NewProjectileDirect(
                    source,
                    position,
                    NewVelocity,
                    type,
                    damage,
                    knockback,
                    player.whoAmI
                    );
            }

            return false; // return false to prevent the gun from shooting original projectile as we created them manually above
        }
        else
        {
            shots++;

            Projectile.NewProjectileDirect(
                    source,
                    position,
                    velocity,
                    type,
                    damage,
                    knockback,
                    player.whoAmI
                    );

            return false;
        }
    }
}
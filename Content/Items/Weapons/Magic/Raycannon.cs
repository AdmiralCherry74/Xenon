using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Magic;

public class Raycannon : ModItem
{
    public override void SetDefaults()
    {
        // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.

        Item.width = 54; // Hitbox width of the item.
        Item.height = 22; // Hitbox height of the item.
        Item.damage = 40;
        Item.scale = 1f;
        Item.shootSpeed = 10f;
        Item.mana = 36;
        Item.DamageType = DamageClass.Magic;
        Item.noMelee = true;
        Item.useTime = 28;
        Item.knockBack = 0.65f;
        Item.crit = 0;
        Item.shoot = ModContent.ProjectileType<RayProj>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 1000;
        Item.useAnimation = 28;
        Item.holdStyle = 3;
        Item.UseSound = SoundID.Item67;
        Item.rare = 4;
        Item.autoReuse = true;
    }

    // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-6f, -2f);
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Ranged;

public class AUG : ModItem
{
    public override void SetDefaults()
    {
        // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.

        Item.width = 54; // Hitbox width of the item.
        Item.height = 22; // Hitbox height of the item.
        Item.damage = 6;
        Item.shootSpeed = 18f;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 10;
        Item.knockBack = 4f; // 0.35 was WAY too small
        Item.crit = 5;
        Item.reuseDelay = 17;
        Item.shoot = ProjectileID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
		Item.consumeAmmoOnLastShotOnly = true;
		Item.value = 1000;
        Item.useAnimation = 30;
        Item.UseSound = SoundID.Item31;
        Item.rare = ItemRarityID.Blue;
        Item.autoReuse = false;
    }

    // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-15f, 2f);
    }
}
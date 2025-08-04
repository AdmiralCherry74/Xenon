using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Ranged.Arms;

public class MP5 : ModItem
{
    public override void SetDefaults()
    {
        // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.

        Item.width = 54;
        Item.height = 22;
        Item.damage = 4;
        Item.scale = 0.80f;
        Item.shootSpeed = 13f;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 6;
        Item.knockBack = 0.35f;
        Item.crit = 12;
        Item.shoot = ProjectileID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 1000;
        Item.useAnimation = 6;
        Item.UseSound = SoundID.Item11;
        Item.rare = 3;
        Item.autoReuse = true;
    }

    // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(10f, 2f);
    }
}
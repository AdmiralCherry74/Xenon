using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Ammo.Grenade;
using Xenon.Content.Projectiles.Ranged.Ammo.Grenade;

namespace Xenon.Content.Items.Weapons.Ranged.Arms
{
    public class WoodenGrenadeLauncher : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.

            Item.width = 18;
            Item.height = 40;
            Item.scale = 1f;
            Item.UseSound = SoundID.Item61;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.autoReuse = false;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 10;
            Item.knockBack = 1f;
            Item.crit = 0;
            Item.noMelee = true;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<ExampleThumperProj>();
            Item.useAmmo = ModContent.ItemType<ExampleThumper>();

            Item.value = 360;
            Item.rare = ItemRarityID.Orange;
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10f, 2f);
        }
    }
}
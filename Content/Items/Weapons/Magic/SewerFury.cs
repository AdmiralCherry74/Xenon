using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Magic
{
    public class SewerFury : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.

            Item.width = 54; // Hitbox width of the item.
            Item.height = 22; // Hitbox height of the item.
            Item.damage = 16;
            Item.scale = 1f;
            Item.mana = 10;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.useTime = 30;
            Item.knockBack = 0.65f;
            Item.crit = 0;
            Item.shoot = ModContent.ProjectileType<SewerFuryBall>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 1000;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item20;
            Item.rare = 2;
            Item.autoReuse = false;
            Item.channel = true;
        }
    }
}
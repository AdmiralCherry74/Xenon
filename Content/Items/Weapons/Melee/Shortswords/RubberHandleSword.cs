using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Shortsword;

namespace Xenon.Content.Items.Weapons.Melee.Shortswords;

public class RubberHandleSword : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 24;
        Item.knockBack = 0.3f;
        Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
        Item.useAnimation = 12;
        Item.useTime = 5;
        Item.width = 32;
        Item.height = 32;
        Item.UseSound = SoundID.Item1;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.autoReuse = true;
        Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
        Item.noMelee = true; // The projectile will do the damage and not the item

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 18);

        Item.shoot = ModContent.ProjectileType<RHSProj>();
        Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
    }
}
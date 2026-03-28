using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Shortsword;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class IndiumShortsword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
        Item.useAnimation = 1;
        Item.useTime = 1;
        Item.UseSound = SoundID.Item1;
        Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
        Item.autoReuse = true;

        Item.damage = 1;
        Item.knockBack = 0.1f;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.noMelee = true; // The projectile will do the damage and not the item
        Item.shoot = ModContent.ProjectileType<IndiumShortswordProj>();
        Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 18);
    }
}
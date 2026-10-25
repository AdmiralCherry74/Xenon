using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Shortsword;

namespace Xenon.Content.Items.Weapons.Melee.Shortswords;

public class WoodenDagger : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;

        Item.useStyle = ItemUseStyleID.Rapier;
        Item.useAnimation = 12;
        Item.useTime = 13;
        Item.UseSound = SoundID.Item1;
        Item.noUseGraphic = true;

        Item.damage = 4;
        Item.knockBack = 3.75f;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.noMelee = true;
        Item.shoot = ModContent.ProjectileType<WoodenDaggerProj>();
        Item.shootSpeed = 2.1f;
    }
}
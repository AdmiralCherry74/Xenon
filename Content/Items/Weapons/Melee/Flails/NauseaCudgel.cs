using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Flail;

namespace Xenon.Content.Items.Weapons.Melee.Flails;

public class NauseaCudgel : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 28;
        Item.channel = true;
        Item.damage = 18;
        Item.DamageType = DamageClass.Melee;
        Item.knockBack = 6.5f;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.shootSpeed = 12f;
        Item.shoot = ModContent.ProjectileType<CorrodedBall>();
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 54);
    }
}
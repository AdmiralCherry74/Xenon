using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Flail;

namespace Xenon.Content.Items.Weapons.Melee.Flails;

public class Warflail : ModItem
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
        Item.damage = 10;
        Item.DamageType = DamageClass.Melee;
        Item.knockBack = 4.8f;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.shootSpeed = 11f;
        Item.shoot = ModContent.ProjectileType<WarflailBall>();
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 52);
    }
}
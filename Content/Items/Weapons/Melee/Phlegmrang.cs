using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles;

namespace Xenon.Content.Items.Weapons.Melee;

public class Phlegmrang : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;
        Item.shoot = ModContent.ProjectileType<PhlegmarangProjectile>();
        Item.shootSpeed = 15f;
        Item.value = Item.buyPrice(gold: 5);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
}
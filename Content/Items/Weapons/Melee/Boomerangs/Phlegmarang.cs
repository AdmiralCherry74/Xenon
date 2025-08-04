using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Projectiles;

namespace Xenon.Content.Items.Weapons.Melee.Boomerangs;

public class Phlegmarang : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.noUseGraphic = true;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;
        Item.shoot = ModContent.ProjectileType<PhlegmarangProjectile>();
        Item.shootSpeed = 15f;
        Item.value = Item.sellPrice(silver: 27);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<UlceriteBar>(), 8)
            .AddIngredient(ModContent.ItemType<FreshChyme>(), 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
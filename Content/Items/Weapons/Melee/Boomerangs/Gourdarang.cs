using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Wall.Natural.Ores;
using Xenon.Content.Projectiles.Melee.Boomerang;

namespace Xenon.Content.Items.Weapons.Melee.Boomerangs;

public class Gourdarang : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 32;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.reuseDelay = 20;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 14;
        Item.knockBack = 5;
        Item.crit = 0;
        Item.shoot = ModContent.ProjectileType<GourdarangProjectile>();
        Item.shootSpeed = 8.5f;
        Item.value = Item.sellPrice(silver: 35);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Blue;
    }
    public override void AddRecipes()
    {
        Recipe.Create(ModContent.ItemType<Gourdarang>())
        .AddIngredient(ItemID.Pumpkin, 15)
        .AddTile(TileID.WorkBenches)
        .SortBeforeFirstRecipesOf(ItemID.EnchantedBoomerang)
        .Register();
    }
}
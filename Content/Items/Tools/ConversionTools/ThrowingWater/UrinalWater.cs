using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Desert;
using Xenon.Content.Items.Placeable.Blocks.Natural.Seed;
using Xenon.Content.Projectiles.Tools.ConvertingTools.ThrowingWater;

namespace Xenon.Content.Items.Tools.ConversionTools.ThrowingWater;

public class UrinalWater : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 99;
    }
    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.shootSpeed = 9f;
        Item.rare = ItemRarityID.Orange;
        Item.damage = 20;
        Item.shoot = ModContent.ProjectileType<UrinalWaterProj>();
        Item.width = 18;
        Item.height = 20;
        Item.maxStack = 9999;
        Item.consumable = true;
        Item.knockBack = 3f;
        Item.UseSound = SoundID.Item1;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.noUseGraphic = true;
        Item.noMelee = true;
        Item.value = 100;
    }
    public override void AddRecipes()
    {
        CreateRecipe(10)
            .AddIngredient(ItemID.BottledWater, 10)
            .AddIngredient(ModContent.ItemType<GutsandBlock>())
            .AddIngredient(ModContent.ItemType<CorrosionSeeds>())
            .SortAfterFirstRecipesOf(ItemID.UnholyWater)
            .Register();
    }
}
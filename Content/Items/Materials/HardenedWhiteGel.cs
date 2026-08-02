using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class HardenedWhiteGel : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Blue;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<WhiteGel>(), 1)
            .AddIngredient(ItemID.SnowBlock)
            .Register();

        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<WhiteGel>(), 1)
            .AddTile(TileID.Solidifier)
            .SortAfterFirstRecipesOf(ModContent.ItemType<HardenedWhiteGel>())
            .Register();

    }
}
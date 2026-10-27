using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Paper : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 30;
        Item.value = Item.sellPrice(0, 0, 0, 25);
        Item.maxStack = 9999;
    }
    public override void AddRecipes()
    {
        Recipe.Create(ItemID.PaperAirplaneA, 4)
            .AddIngredient(ModContent.ItemType<Paper>(), 2)
            .AddTile(TileID.WorkBenches)
            .SortBeforeFirstRecipesOf(ItemID.EnchantedBoomerang)
            .Register();

        Recipe.Create(ItemID.PaperAirplaneB, 4)
            .AddIngredient(ModContent.ItemType<Paper>(), 2)
            .AddTile(TileID.WorkBenches)
            .SortBeforeFirstRecipesOf(ItemID.PaperAirplaneB)
            .Register();

        Recipe.Create(ModContent.ItemType<Paper>(), 5)
            .AddIngredient(ItemID.BambooBlock)
            .AddTile(TileID.WorkBenches)
            .SortBeforeFirstRecipesOf(ItemID.CopperCoin)
            .Register();

        Recipe.Create(ItemID.Book)
            .AddIngredient(ItemID.Leather, 2)
            .AddIngredient(ModContent.ItemType<Paper>(), 12)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Paper>())
            .Register();
    }
}
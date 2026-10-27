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
        CreateRecipe(5)
        .AddIngredient(ItemID.BambooBlock)
        .AddTile(TileID.WorkBenches)
        .SortBeforeFirstRecipesOf(ItemID.CopperCoin)
        .Register();
    }
}
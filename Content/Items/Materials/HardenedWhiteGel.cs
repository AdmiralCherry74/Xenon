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
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<WhiteGel>());
        recipe.AddTile(TileID.Furnaces);
        recipe.Register();
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class HardenedWhiteGel : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Item.value = Item.buyPrice(silver: 10);
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 9999;
    }
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<WhiteGel>());
        recipe.AddTile(TileID.Furnaces);
        recipe.Register();
    }
}
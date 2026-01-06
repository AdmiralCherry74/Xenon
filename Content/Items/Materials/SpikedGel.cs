using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class SpikedGel : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Item.value = Item.buyPrice(silver: 10);
        Item.rare = 1;
    }
}
    //public override void AddRecipes()
        //Recipe recipe = CreateRecipe();
        //recipe.AddIngredient(ItemID.Silk, 5);
        //recipe.AddTile(TileID.Tables);
        //recipe.AddTile(TileID.Chairs);
        //recipe.Register();
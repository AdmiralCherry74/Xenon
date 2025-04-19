using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Components
{
    public class Pouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            Item.value = Terraria.Item.buyPrice(silver:10);
            Item.rare = -11;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}
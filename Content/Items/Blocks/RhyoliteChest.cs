using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Blocks
{
    public class RhyoliteChest: ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Storage.RhyoliteChest>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>(), 8);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
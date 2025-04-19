using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Blocks;

namespace Xenon.Content.Items.Blocks
{
    public class RhyoliteWorkBench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Workbench.RhyoliteWorkBench>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>(), 10);
            recipe.Register();
        }
    }
}
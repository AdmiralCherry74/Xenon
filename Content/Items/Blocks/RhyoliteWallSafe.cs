using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Walls;

namespace Xenon.Content.Items.Blocks
{
    public class RhyoliteWallSafe : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Walls.RhyoliteWallSafe>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RhyoliteBlock>());
        }
    }
}
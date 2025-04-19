using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Blocks
{
    public class RhyoliteBathtub: ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Bathtub.RhyoliteBathtub>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
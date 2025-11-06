using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;

namespace Xenon.Content.Items.Placeable.Tile
{
    public class TintedGlass : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.TintedGlass>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);

            recipe.AddIngredient(ItemID.Glass, 4);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
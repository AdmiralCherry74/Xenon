using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.DecorationalTiles
{
    public class WoolBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.Decoration.WoolBlock>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Cobweb, 4);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.Wiring.Lighting
{
    public class OnyxGemsparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Lighting.OnyxGemsparkBlock>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.Onyx>(), 1);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
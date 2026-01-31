using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting
{
    public class ArgonMossparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ActiveAndWiring.Lighting.ArgonMossparkBlock>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ArgonMoss);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
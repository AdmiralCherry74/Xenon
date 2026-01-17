using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting
{
    public class OnyxGemsparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ActiveAndWiring.Lighting.OnyxGemsparkBlock>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 1);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
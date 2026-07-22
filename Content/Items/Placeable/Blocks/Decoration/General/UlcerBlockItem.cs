using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Tiles.Building.Decorational;

namespace Xenon.Content.Items.Placeable.Blocks.Decoration.General
{
    public class UlcerBlockItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<UlcerBlock>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GutstoneBlock>(), 2);
            recipe.AddTile(TileID.MeatGrinder);
            recipe.Register();
        }
    }
}
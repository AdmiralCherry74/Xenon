using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles;
using Xenon.Content.Tiles.Natural.SnowAndIce;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Snow
{
    public class PermafrostDirtIceBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<PermafrostDirtIce>());
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.DirtBlock);
            recipe1.AddCondition(Condition.InSnow);
            recipe1.AddCondition(Condition.InRain);
            recipe1.SortAfterFirstRecipesOf(ItemID.MudBlock);
            recipe1.Register();

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowBlock);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SortAfterFirstRecipesOf(ItemID.MudBlock);
            recipe.Register();
        }
    }
}
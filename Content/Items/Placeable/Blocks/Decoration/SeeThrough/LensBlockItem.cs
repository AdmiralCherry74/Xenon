using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;

namespace Xenon.Content.Items.Placeable.Blocks.Decoration.SeeThrough
{
    public class LensBlockItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.LensBlock>());
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);

            recipe.AddIngredient(ItemID.Lens, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
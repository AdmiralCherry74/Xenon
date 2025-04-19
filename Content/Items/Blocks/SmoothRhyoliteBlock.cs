using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Components;

namespace Xenon.Content.Items.Blocks
{
    public class SmoothRhyoliteBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SmoothRhyoliteBlock>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RhyoliteBlock>())
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RhyolitePlatform>(), 2)
                .Register();
        }
    }
}
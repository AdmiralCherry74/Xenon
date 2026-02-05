using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class AncientCopperOreItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AncientCopperOre>());
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperOre)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.CopperOre)
                .AddIngredient(ModContent.ItemType<AncientCopperOreItem>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.CopperBar)
            .AddIngredient(ModContent.ItemType<AncientCopperOreItem>())
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
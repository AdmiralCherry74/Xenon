using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class AncientGoldOreItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AncientGoldOre>());
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldOre)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.GoldOre)
                .AddIngredient(ModContent.ItemType<AncientGoldOreItem>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.GoldBar)
            .AddIngredient(ModContent.ItemType<AncientGoldOreItem>())
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
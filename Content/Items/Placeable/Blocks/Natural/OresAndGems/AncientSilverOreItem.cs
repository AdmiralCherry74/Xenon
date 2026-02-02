using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class AncientSilverOreItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AncientSilverOre>());
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverOre)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.SilverOre)
                .AddIngredient(ModContent.ItemType<AncientSilverOreItem>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.SilverBar)
            .AddIngredient(ModContent.ItemType<AncientSilverOreItem>())
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
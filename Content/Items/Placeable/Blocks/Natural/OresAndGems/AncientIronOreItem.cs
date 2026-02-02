using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class AncientIronOreItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AncientIronOre>());
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronOre)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.IronOre)
                .AddIngredient(ModContent.ItemType<AncientIronOreItem>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.IronBar)
            .AddIngredient(ModContent.ItemType<AncientIronOreItem>())
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
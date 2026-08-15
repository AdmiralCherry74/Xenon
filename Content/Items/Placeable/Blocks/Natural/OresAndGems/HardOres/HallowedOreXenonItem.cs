using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;
using Xenon.Content.Tiles.Natural.Ores.HardOres;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.HardOres
{
    public class HallowedOreXenonItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HallowedOreXenon>());
            Item.rare = ItemRarityID.LightRed;
        }
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.HallowedBar)
            .AddIngredient(ModContent.ItemType<HallowedOreXenonItem>(), 5)
            .AddTile(TileID.AdamantiteForge)
            .SortBeforeFirstRecipesOf(ItemID.HallowedMask)
            .Register();
        }
    }
}
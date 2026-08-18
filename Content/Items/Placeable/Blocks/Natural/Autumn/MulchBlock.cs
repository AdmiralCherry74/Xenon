// What libraries we use in the code
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Items.Placeable.Wall.Natural.Stone;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Autumn
{
    public class MulchBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Mulch>());
            
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<MulchBlock>(), 5)
            .AddIngredient(ItemID.DirtBlock, 5)
            .AddRecipeGroup(RecipeGroupID.Wood)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ItemID.MudBlock)
            .Register();
        }
    }
}
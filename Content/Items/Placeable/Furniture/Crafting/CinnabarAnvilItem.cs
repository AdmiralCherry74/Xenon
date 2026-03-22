using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Tiles.Furniture.CraftingStations;

namespace Xenon.Content.Items.Placeable.Furniture.Crafting
{
    public class CinnabarAnvilItem : ModItem
    {

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CinnabarAnvil>());
            Item.width = 30;
            Item.height = 26;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 4, 50);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 6)
                .AddTile(TileID.WorkBenches).Register();
        }
    }
}
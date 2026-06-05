using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodPiano : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodPiano>());
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(copper: 60);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ModContent.ItemType<BilewoodItem>(), 15)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.Sawmill).Register();
    }
}

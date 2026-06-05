using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Tiles.Furniture.Bilewood;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodDoor : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<BilewoodDoorClosed>());
        Item.width = 14;
        Item.height = 28;
        Item.value = Item.sellPrice(copper: 40);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<BilewoodItem>(), 6)
            .AddTile(TileID.WorkBenches).Register();
    }
}

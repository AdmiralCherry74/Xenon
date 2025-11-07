using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.BuildingTiles.Stone;
using Xenon.Content.Tiles.Decoration.Furniture.Rhyolite;

namespace Xenon.Content.Items.Placeable.Furniture.Rhyolite;

public class RhyoliteDoor : ModItem
{
    public override void SetDefaults()
    {
        
        Item.consumable = true;
        Item.createTile = ModContent.TileType<RhyoliteDoorClosed>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 200;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>(), 6)
            .AddTile(TileID.WorkBenches).Register();
    }
}

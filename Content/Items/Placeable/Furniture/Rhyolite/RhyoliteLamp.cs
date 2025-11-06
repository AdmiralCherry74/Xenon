using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Rhyolite;

public class RhyoliteLamp : ModItem
{
    public override void SetDefaults()
    {
        
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteLamp>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 500;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.BuildingBlocks.SmoothRhyoliteBlock>(), 3)
            .AddTile(TileID.WorkBenches).Register();
    }
}

using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;

namespace Xenon.Content.Items.Placeable.Furniture.Rhyolite;

public class RhyoliteTable : ModItem
{
    public override void SetDefaults()
    {
        
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteTable>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 300;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>(), 8)
            .AddTile(TileID.WorkBenches).Register();
    }
}

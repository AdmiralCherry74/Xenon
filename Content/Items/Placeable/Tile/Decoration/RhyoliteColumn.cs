using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.BuildingTiles.Stone;

namespace Xenon.Content.Items.Placeable.Tile.Decoration;

public class RhyoliteColumn : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 50;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.RhyoliteColumn>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }
    public override void AddRecipes()
    {
        Terraria.Recipe.Create(Type, 2)
            .AddIngredient(ModContent.ItemType<SmoothRhyoliteBlock>())
            .AddTile(TileID.Sawmill).Register();
    }
}

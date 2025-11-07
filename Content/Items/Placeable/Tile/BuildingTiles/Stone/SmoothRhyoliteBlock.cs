using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.Natural.Stone;
using Xenon.Content.Tiles.BuildingTiles.Stones;

namespace Xenon.Content.Items.Placeable.Tile.BuildingTiles.Stone;

public class SmoothRhyoliteBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }
    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Blocks;
    }
    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<SmoothRhyolite>();
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
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<RhyoliteBlock>())
            .AddTile(TileID.WorkBenches)
            .Register();
	}
}

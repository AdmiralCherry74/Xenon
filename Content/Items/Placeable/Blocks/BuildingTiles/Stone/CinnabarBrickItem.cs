using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Tiles.Building.Bricks;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;

public class CinnabarBrickItem : ModItem
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
        Item.createTile = ModContent.TileType<CinnabarBrick>();
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
        Recipe.Create(ModContent.ItemType<CinnabarBrickItem>(), 5)
            .AddIngredient(ItemID.StoneBlock, 5)
            .AddIngredient(ModContent.ItemType<CinnabarOreBlock>())
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ItemID.IronBrick)
            .Register();
    }
}

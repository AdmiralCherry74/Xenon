using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Tiles;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Other;

public class BoggedPearlwoodItem : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        ItemID.Sets.DrawUnsafeIndicator[Type] = true;
    }
    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Blocks;
    }
    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<BoggedPearlwood>();
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
            .AddIngredient(ModContent.ItemType<Sludge>(), 1)
            .AddIngredient(ItemID.Pearlwood, 1)
            .AddTile(TileID.Solidifier)
            .SortBeforeFirstRecipesOf(ItemID.Pearlwood)
            .Register();
    }
}

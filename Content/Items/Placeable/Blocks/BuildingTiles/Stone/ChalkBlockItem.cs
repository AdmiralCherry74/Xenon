using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables.NomNoms.OreFood;
using Xenon.Content.Items.Materials;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Building.BuildingStone;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;

public class ChalkBlockItem : ModItem
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
        Item.createTile = ModContent.TileType<ChalkBlock>();
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
        Recipe.Create(ModContent.ItemType<ChalkBlockItem>())
        .AddIngredient(ItemID.StoneBlock)
        .AddIngredient(ModContent.ItemType<WhiteGel>())
        .AddTile(TileID.Furnaces)
        .Register();
    }
}

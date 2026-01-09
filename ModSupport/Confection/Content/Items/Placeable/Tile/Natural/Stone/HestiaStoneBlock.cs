using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone;

namespace Xenon.ModSupport.Confection.Content.Items.Placeable.Tile.Natural.Stone;

public class HestiaStoneBlock : ModItem
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
        Item.createTile = ModContent.TileType<HestiaStone>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }
}

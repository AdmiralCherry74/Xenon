using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Tiles.Natural.LivingWood.LeafBlocks;

namespace Xenon.Content.Items.Tools.BlockPlacingWands;

public class DissolvingBileleafWand : ModItem
{
    public override void SetDefaults()
    {
        Item.useTime = 10;
        Item.useAnimation = 15;
        Item.width = 32;
        Item.height = 32;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 30);
        Item.createTile = ModContent.TileType<DissolvingBileleafBlock>();
        Item.tileWand = ModContent.ItemType<Bilewood>();
    }
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
}
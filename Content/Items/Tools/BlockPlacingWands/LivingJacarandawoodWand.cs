using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Tiles.Natural.LivingWood;

namespace Xenon.Content.Items.Tools.BlockPlacingWands;

public class LivingJacarandawoodWand : ModItem
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
		Item.createTile = ModContent.TileType<LivingJacarandawoodBlock>();
		Item.tileWand = ModContent.ItemType<JacarandaWood>();
	}
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
}
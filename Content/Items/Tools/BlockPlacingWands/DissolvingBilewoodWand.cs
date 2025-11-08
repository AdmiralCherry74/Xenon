using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Items.Placeable.Tile.BuildingTiles.Wood;
using Xenon.Content.Tiles.BuildingTiles.Stones;
using Xenon.Content.Tiles.Natural.LivingWood;

namespace Xenon.Content.Items.Tools.BlockPlacingWands;

public class DissolvingBilewoodWand : ModItem
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
		Item.createTile = ModContent.TileType<DissolvingBilewoodBlock>();
		Item.tileWand = ModContent.ItemType<Bilewood>();
    }
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
}
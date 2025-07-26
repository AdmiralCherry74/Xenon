using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile;

public class UlceriteOre : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Corrosion.UlceriteOre>());
        Item.value = Item.sellPrice(0, 0, 7);
    }
}

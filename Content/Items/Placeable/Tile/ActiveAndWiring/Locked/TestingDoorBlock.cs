using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Locked;

namespace Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Locked;

public class TestingDoorBlock : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<LockedLivingJacarandawoodDoor>());
		Item.width = 14;
		Item.height = 28;
		Item.value = Item.sellPrice(copper: 40);
	}
}
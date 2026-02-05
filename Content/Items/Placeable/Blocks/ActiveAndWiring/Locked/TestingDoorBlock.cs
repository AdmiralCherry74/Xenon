using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.LivingWood;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Locked;

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
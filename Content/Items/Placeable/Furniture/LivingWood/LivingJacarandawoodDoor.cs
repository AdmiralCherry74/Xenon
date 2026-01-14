using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.LivingWood;

namespace Xenon.Content.Items.Placeable.Furniture.LivingWood;

public class LivingJacarandawoodDoor : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<LivingJacarandawoodDoorClosed>());
		Item.width = 14;
		Item.height = 28;
		Item.value = Item.sellPrice(copper: 40);
	}
}
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Content.Tiles.Furniture.LivingWood
{
    public class LivingJacarandawoodDoorClosed : ClosedDoorTemplate
    {
        public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.LivingWood.LivingJacarandawoodDoor>();
    }

    public class LivingJacarandawoodDoorOpen : OpenDoorTemplate
    {
        public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.LivingWood.LivingJacarandawoodDoor>();
    }
}
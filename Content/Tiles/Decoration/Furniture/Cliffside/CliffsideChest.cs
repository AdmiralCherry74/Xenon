using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Content.Tiles.Decoration.Furniture.Cliffside
{
    public class CliffsideChest : ChestTemplate
    {
        public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Cliffside.CliffsideChest>();
    }
}
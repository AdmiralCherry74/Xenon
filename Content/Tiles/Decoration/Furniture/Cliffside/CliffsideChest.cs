using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Content.Tiles.Decoration.Furniture.Cliffside
{
    public class CliffsideChest : ChestTemplate
    {
        public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodChest>();
    }
}
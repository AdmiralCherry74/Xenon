using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Chandelier;

namespace Xenon.Content.Tiles.Furniture.OreBasedFurniture.Chandelier
{
    public class IndiumChandelierPlaced : ChandelierTemplate
    {
        public override int DropItem => ModContent.ItemType<IndiumChandelier>();
    }
}

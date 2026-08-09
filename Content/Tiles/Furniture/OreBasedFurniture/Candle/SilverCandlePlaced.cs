using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Candle;

namespace Xenon.Content.Tiles.Furniture.OreBasedFurniture.Candle
{
    public class SilverCandlePlaced : CandleTemplate
    {
        public override int DropItem => ModContent.ItemType<SilverCandle>();
    }
}
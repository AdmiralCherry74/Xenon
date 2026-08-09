using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Candle;

namespace Xenon.Content.Tiles.Furniture.OreBasedFurniture.Candle
{
    public class TinCandlePlaced : CandleTemplate
    {
        public override int DropItem => ModContent.ItemType<TinCandle>();
    }
}
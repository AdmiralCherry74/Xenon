using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.Natural.Stones;

namespace Xenon.Common.Globals;

public class XenonGlobalItem : GlobalItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ShimmerTransformToItem[ItemID.Marble] = ItemID.Granite;
        ItemID.Sets.ShimmerTransformToItem[ItemID.Granite] = ModContent.ItemType<RhyoliteBlock>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RhyoliteBlock>()] = ItemID.Marble;
    }
}

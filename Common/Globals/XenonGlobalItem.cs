using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.Natural.Stone;
using Xenon.Content.Items.Weapons.Melee.Swords;

namespace Xenon.Common.Globals;

public class XenonGlobalItem : GlobalItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ShimmerTransformToItem[ItemID.Marble] = ItemID.Granite;
        ItemID.Sets.ShimmerTransformToItem[ItemID.Granite] = ModContent.ItemType<RhyoliteBlock>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RhyoliteBlock>()] = ItemID.Marble;
        ItemID.Sets.ShimmerTransformToItem[ItemID.TerraBlade] = ModContent.ItemType<AncientTerraBlade>();
    }
}

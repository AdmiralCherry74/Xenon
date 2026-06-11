using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.TheMirage;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Seed;

public class ArigrowthSeeds : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        Item.ResearchUnlockCount = 25;
    }
    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.AlchemySeeds;
    }
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Arigrowth>());
        Item.value = Item.sellPrice(0, 0, 0, 16);
    }
}

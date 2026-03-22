using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;

public class IngestaneOre : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Ores.IngestaneOre>());
        Item.value = Item.sellPrice(0, 0, 7);
    }
}

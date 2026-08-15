using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;

public class IngestaneOre : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Ores.PreHardOres.IngestaneOre>());
        Item.value = Item.sellPrice(0, 0, 7);
		Item.rare = ItemRarityID.Blue;
    }
}

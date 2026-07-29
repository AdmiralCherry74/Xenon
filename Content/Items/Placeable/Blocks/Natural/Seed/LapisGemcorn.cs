using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores.Gems.GemTrees;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Seed;

public class LapisGemcorn : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 5;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<LapisSapling>());
		Item.value = Item.sellPrice(0, 0, 11, 25);
	}
}

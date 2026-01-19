using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Materials.Fish.Valuable;

public class ExampleFish : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 10;
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 26;
		Item.maxStack = 10;
        Item.rare = ModContent.RarityType<Janaury>(); //this is an example fish so it doesnt matter
        Item.value = Item.sellPrice(0, 10, 0, 0);
	}
}

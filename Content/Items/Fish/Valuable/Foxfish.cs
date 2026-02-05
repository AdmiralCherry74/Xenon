using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Fish.Valuable;

public class Foxfish : ModItem
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
        Item.rare = ModContent.RarityType<November>(); //this will be fished during the month November
        Item.value = Item.sellPrice(0, 10, 0, 0);
	}
}

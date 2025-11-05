using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class VitriolicMushroom : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}
	//public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
	//{
	//	itemGroup = Data.Sets.ItemGroupValues.Contagion;
	//}
	public override void SetDefaults()
	{
		Item.width = 14;
		Item.height = 22;
		Item.maxStack = 9999;
		Item.value = Item.sellPrice(copper: 10);
	}
}

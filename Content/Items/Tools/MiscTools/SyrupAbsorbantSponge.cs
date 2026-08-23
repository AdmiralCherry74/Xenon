using Xenon.Content.Liquids;
using ModLiquidLib.ID;
using ModLiquidLib.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Tools.MiscTools
{
	//This is an example of a modded sponge
	//Here we make this item only absorb Example Liquid using very similar logic from that of ExampleLiquidBucket
	public class SyrupAbsorbantSponge : ModItem
	{
		//The SetStaticDefaults of a sponge
		public override void SetStaticDefaults()
		{
			ItemID.Sets.AlsoABuildingItem[Type] = true; //Unused, but useful to have here for both other mods and future game updates
			ItemID.Sets.DuplicationMenuToolsFilter[Type] = true;
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.HoneyAbsorbantSponge;

			//Unlike buckets, sponges have extra functionality to allow the removing and adding of sponge items to liquids
			LiquidID_TLmod.Sets.CanBeAbsorbedBy[LiquidLoader.LiquidType<Syrup>()].Add(Type);

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		//The SetDefaults of a sponge
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 12;
			Item.useTime = 5;
			Item.width = 20;
			Item.height = 20;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(0, 10);
			Item.tileBoost += 2;
		}
	}
}
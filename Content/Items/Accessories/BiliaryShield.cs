using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Xenon.Content.Items.Accessories;

public class BiliaryShield : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToAccessory();
		Item.sellPrice(gold: 1);
		Item.rare = ItemRarityID.Blue;
	}
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statLifeMax2 += 25;
	}
}

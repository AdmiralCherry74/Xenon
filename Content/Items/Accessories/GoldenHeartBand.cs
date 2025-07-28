using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Xenon.Content.Items.Accessories;

public class GoldenHeartBand : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToAccessory();
		Item.sellPrice(gold: 1);
		Item.rare = ItemRarityID.Green;
	}
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statLifeMax2 += 25;
	}
}

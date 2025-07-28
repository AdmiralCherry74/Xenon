using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Pets;

public class RottingLeftovers : ModItem
{
	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.AddBuff(Item.buffType, 3600);
		}
	}
	public override void SetDefaults()
	{
		Item.DefaultToVanitypet(ModContent.ProjectileType<Projectiles.Pets.RottingLeftovers>(), ModContent.BuffType<Buffs.Pets.RottingLeftovers>());
		Item.UseSound = SoundID.Item8;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.sellPrice(0, 1, 50);
	}
}

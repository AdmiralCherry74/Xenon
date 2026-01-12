using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Pets;

public class SeedPacket : ModItem
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
		Item.DefaultToVanitypet(ModContent.ProjectileType<Projectiles.Pets.GraveBuster>(), ModContent.BuffType<Buffs.Pets.GraveBuster>());
		Item.UseSound = SoundID.Grass;
		Item.rare = ItemRarityID.Pink;
		Item.value = Item.sellPrice(0, 1);
	}
}

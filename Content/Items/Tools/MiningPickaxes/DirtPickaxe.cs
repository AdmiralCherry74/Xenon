using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Tools.MiningPickaxes;

public class DirtPickaxe : ModItem
{
	public override void SetDefaults()
	{
		Item.pick = 1;
		Item.knockBack = 0.5f;
		Item.useTime = 13;
		Item.useAnimation = 21;
		Item.width = 24;
		Item.height = 24;
		Item.DamageType = DamageClass.Melee;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.autoReuse = true;
		Item.useTurn = true;
		Item.UseSound = SoundID.Item1;
		Item.rare = ItemRarityID.Gray;
	}
	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (player.itemAnimation % 2 == 0)
		{
			SpecialUtilities.GetPointOnSwungItemPath(60f, 60f, 0.3f + 0.3f * Main.rand.NextFloat(), Item.scale, out var location2, out var outwardDirection2, player);
			Vector2 vector2 = outwardDirection2.RotatedBy((float)Math.PI / 2f * player.direction * player.gravDir);
			int DustType = DustID.Dirt;
			if (Main.rand.NextBool(3))
				DustType = DustID.DirtSpray;

			int num15 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType, player.velocity.X * 0.2f + player.direction * 3, player.velocity.Y * 0.2f, 140, default, 0.7f);
			Main.dust[num15].position = location2;
			Main.dust[num15].fadeIn = 1.2f;
			Main.dust[num15].noGravity = true;
			Main.dust[num15].velocity *= 0.25f;
			Main.dust[num15].velocity += vector2 * 5f;
			Main.dust[num15].velocity.Y *= 0.3f;
		}
	}
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.DirtBlock, 8)
			.AddIngredient(ItemID.Wood, 4)
			.Register();
	}
}

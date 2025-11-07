using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;

namespace Xenon.Content.Items.Placeable.Tile.Decoration.Torches;

public class GrayTorch : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
		ItemID.Sets.SingleUseInGamepad[Type] = true;
		ItemID.Sets.Torches[Type] = true;
	}

	public override void SetDefaults()
	{
		Item.DefaultToTorch(ModContent.TileType<Tiles.GrayTorch>(), 0, false);
		Item.value = Item.sellPrice(0, 0, 0, 40);
		Item.notAmmo = true;
		Item.ammo = ItemID.Torch;
	}
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(3);

        recipe.AddIngredient(ItemID.Torch, 3);
        recipe.AddIngredient(ModContent.ItemType<Onyx>(), 1);
        recipe.Register();
    }
    public override void HoldItem(Player player)
	{
		if (!player.wet)
		{
			if (Main.rand.NextBool(player.itemAnimation > 0 ? 10 : 20))
			{
                Dust d = Dust.NewDustDirect(new Vector2(player.itemLocation.X + (player.direction == 1 ? 6 : -16), player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.Asphalt, 0, 0, 0, default, Main.rand.NextFloat(0.5f, 1));
                d.velocity.Y = Main.rand.NextFloat(-0.5f, -2);
				d.velocity.X *= 0.2f;
			}
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 0.5f, 0.5f, 0.5f);
        }
	}

	public override void PostUpdate()
	{
		if (!Item.wet)
		{
			Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.5f, 0.5f, 0.5f);
		}
	}
}

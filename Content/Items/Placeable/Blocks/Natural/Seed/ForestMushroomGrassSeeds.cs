using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.ForestMushroom;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Seed;

public class ForestMushroomGrassSeeds : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}

	public override void SetDefaults()
	{
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.consumable = true;
		Item.width = 14;
		Item.height = 14;
		Item.useTime = 10;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.maxStack = Item.CommonMaxStack;
		Item.value = Item.buyPrice(silver: 5);
	}

	public override void HoldItem(Player player)
	{
		if (Main.myPlayer == player.whoAmI)
		{
			if (player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
			{
				player.cursorItemIconEnabled = true;
				player.cursorItemIconID = Type;
			}
		}
	}

	public override bool? UseItem(Player player)
	{
		Terraria.Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
		if (tile.HasTile && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
		{
			if (tile.TileType == TileID.Dirt)
			{
				Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<MushroomGrass>();
				WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
				SoundEngine.PlaySound(SoundID.Dig, player.Center);
				return true;
			}
        }
        return false;
    }
}

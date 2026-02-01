using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Hooks;

internal class PickPower : ModHook
{
	protected override void Apply()
	{
		On_Player.GetPickaxeDamage += On_Player_GetPickaxeDamage;
	}

	private int On_Player_GetPickaxeDamage(On_Player.orig_GetPickaxeDamage orig, Player self, int x, int y, int pickPower, int hitBufferIndex, Tile tileTarget)
	{
		if (!ModContent.GetInstance<XenonConfig>().PickaxeRequiredForNextOreTier) return orig.Invoke(self, x, y, pickPower, hitBufferIndex, tileTarget);
		int num = orig.Invoke(self, x, y, pickPower, hitBufferIndex, tileTarget);
		if (tileTarget.TileType is TileID.Silver or TileID.Tungsten && pickPower < 40)
		{
			num = 0;
		}
		if (tileTarget.TileType is TileID.Gold or TileID.Platinum && pickPower < 45)
		{
			num = 0;
		}
		if (ModLoader.TryGetMod("Avalon", out Mod avalon))
		{
			if (tileTarget.TileType == avalon.Find<ModTile>("ZincOre").Type && pickPower < 40)
			{
				num = 0;
			}
			if (tileTarget.TileType == avalon.Find<ModTile>("BismuthOre").Type && pickPower < 45)
			{
				num = 0;
			}
		}
		return num;
	}
}
internal class PickPower2 : ModHook
{
	protected override void Apply()
	{
		On_Player.GetPickaxeDamage += On_Player_GetPickaxeDamage;
	}

	private int On_Player_GetPickaxeDamage(On_Player.orig_GetPickaxeDamage orig, Player self, int x, int y, int pickPower, int hitBufferIndex, Tile tileTarget)
	{
		int num = orig.Invoke(self, x, y, pickPower, hitBufferIndex, tileTarget);
		if (Main.tileDungeon[tileTarget.TileType] && pickPower < 75)
		{
			num = 0;
		}	
		return num;
	}
}

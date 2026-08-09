using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

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
		if ((tileTarget.TileType == TileID.Silver || tileTarget.TileType == TileID.Tungsten || tileTarget.TileType == ModContent.TileType<IndiumOre>()) && pickPower < 40)
		{
			num = 0;
		}
		if ((tileTarget.TileType == TileID.Gold || tileTarget.TileType == TileID.Platinum || tileTarget.TileType == ModContent.TileType<FluoriteOre>()) && pickPower < 45)
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

internal class MechanicalToolRework : ModHook
{
    protected override void Apply()
    {
        On_Player.GetPickaxeDamage += On_Player_GetPickaxeDamage;
    }

    private int On_Player_GetPickaxeDamage(On_Player.orig_GetPickaxeDamage orig, Player self, int x, int y, int pickPower, int hitBufferIndex, Tile tileTarget)
    {
        int num = orig.Invoke(self, x, y, pickPower, hitBufferIndex, tileTarget);
        if (Common.Data.ItemSets.MechanicalToolReworkItemSet[self.inventory[self.selectedItem].type])
        {
			num *= 2;
        }
        return num;
    }
}

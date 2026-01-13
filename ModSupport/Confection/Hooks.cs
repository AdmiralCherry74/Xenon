using MonoMod.Cil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Hooks;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.ModSupport.Confection;

public class ConfectionTileSolidHook : ModHook
{
	protected override void Apply()
	{
		if (XenonMod.TheConfectionRebirthContentEnabled)
		{
			On_Liquid.Update += On_Liquid_Update;
			On_Main.UpdateTime += On_Main_UpdateTime;
			On_Main.DoUpdateInWorld += On_Main_DoUpdateInWorld;

			IL_WorldGen.PaintTheSand += IL_AddStalacCheck;
			IL_WorldGen.PlaceTile += IL_AddStalacCheck;
			IL_WorldGen.PlaceTight += IL_AddStalacCheck;
			IL_WorldGen.BlockBelowMakesSandFall += IL_AddStalacCheck;
			IL_WorldGen.TileFrame += IL_AddStalacCheck;
			IL_WorldGen.UpdateWorld_OvergroundTile += IL_AddStalacCheck;
			IL_WorldGen.UpdateWorld_UndergroundTile += IL_AddStalacCheck;
			IL_WorldGen.ReplaceTile_EliminateNaturalExtras += IL_AddStalacCheck;

			On_WorldGen.GetDesiredStalagtiteStyle += On_WorldGen_GetDesiredStalactiteStyle;
		}
	}

	private static void On_WorldGen_GetDesiredStalactiteStyle(On_WorldGen.orig_GetDesiredStalagtiteStyle orig, int x, int j, out bool fail, out int desiredStyle, out int height, out int y)
	{
		orig(x, j, out fail, out desiredStyle, out height, out y);
		switch (fail)
		{
			case true when desiredStyle == ModContent.TileType<PolloStone>():
				fail = false;
				desiredStyle = 7;
				for (var i = y; i < y + height; i++)
				{
					Main.tile[x, i].TileType = (ushort)ModContent.TileType<HestiaStalac>();
				}
				break;

			case false when Main.tile[x, j].TileType == ModContent.TileType<HestiaStalac>():
				for (var i = y; i < y + height; i++)
				{
					Main.tile[x, i].TileType = TileID.Stalactite;
				}
				break;
		}
	}
	private static void IL_AddStalacCheck(ILContext il)
	{
		HookUtilities.AddAlternativeIdChecks(il, TileID.Stalactite, id => Common.Data.TileSets.Stalac.Contains(id));
	}
	private void On_Main_DoUpdateInWorld(On_Main.orig_DoUpdateInWorld orig, Main self, System.Diagnostics.Stopwatch sw)
	{
		Main.tileSolid[ModContent.TileType<Creamquicksand>()] = false;
		orig.Invoke(self, sw);
	}

	private void On_Main_UpdateTime(On_Main.orig_UpdateTime orig)
	{
		orig.Invoke();
		Main.tileSolid[ModContent.TileType<Creamquicksand>()] = true;
	}

	private void On_Liquid_Update(On_Liquid.orig_Update orig, Liquid self)
	{
		Main.tileSolid[ModContent.TileType<Creamquicksand>()] = true;
		orig.Invoke(self);
	}
}

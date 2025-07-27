using Terraria;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Hooks;

internal class TileSolidHook : ModHook
{
	protected override void Apply()
	{
		On_Liquid.Update += On_Liquid_Update;
		On_Main.UpdateTime += On_Main_UpdateTime;
		On_Main.DoUpdateInWorld += On_Main_DoUpdateInWorld;
	}

	private void On_Main_DoUpdateInWorld(On_Main.orig_DoUpdateInWorld orig, Main self, System.Diagnostics.Stopwatch sw)
	{
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quickmud>()] = false;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Crimquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Ebonquicksand>()] = false;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Pearlquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Content.Tiles.PowderedSnow>()] = false;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Gutquicksand>()] = false;
        orig.Invoke(self, sw);
	}

	private void On_Main_UpdateTime(On_Main.orig_UpdateTime orig)
	{
		orig.Invoke();
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.PowderedSnow>()] = true;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Gutquicksand>()] = true;
    }

	private void On_Liquid_Update(On_Liquid.orig_Update orig, Liquid self)
	{
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Content.Tiles.PowderedSnow>()] = true;
        Main.tileSolid[ModContent.TileType<Content.Tiles.Gutquicksand>()] = true;
        orig.Invoke(self);
	}
}

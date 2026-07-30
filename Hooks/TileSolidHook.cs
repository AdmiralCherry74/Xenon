using Terraria;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;

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
		Main.tileSolid[ModContent.TileType<Quickmud>()] = false;
		Main.tileSolid[ModContent.TileType<Quicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Crimquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Ebonquicksand>()] = false;
        Main.tileSolid[ModContent.TileType<Pearlquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<PowderedSnow>()] = false;
		Main.tileSolid[ModContent.TileType<Gutquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<MarineQuicksand>()] = false;
        Main.tileSolid[ModContent.TileType<Quickgravel>()] = false;
        orig.Invoke(self, sw);
	}

	private void On_Main_UpdateTime(On_Main.orig_UpdateTime orig)
	{
		orig.Invoke();
		Main.tileSolid[ModContent.TileType<Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<PowderedSnow>()] = true;
		Main.tileSolid[ModContent.TileType<Gutquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<MarineQuicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Quickgravel>()] = true;
    }

	private void On_Liquid_Update(On_Liquid.orig_Update orig, Liquid self)
	{
		Main.tileSolid[ModContent.TileType<Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<PowderedSnow>()] = true;
		Main.tileSolid[ModContent.TileType<Gutquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<MarineQuicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Quickgravel>()] = true;
        orig.Invoke(self);
	}
}

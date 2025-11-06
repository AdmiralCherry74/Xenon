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
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quickmud>()] = false;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Crimquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Ebonquicksand>()] = false;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Pearlquicksand>()] = false;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.PowderedSnow>()] = false;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Gutquicksand>()] = false;
        orig.Invoke(self, sw);
	}

	private void On_Main_UpdateTime(On_Main.orig_UpdateTime orig)
	{
		orig.Invoke();
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.PowderedSnow>()] = true;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Gutquicksand>()] = true;
    }

	private void On_Liquid_Update(On_Liquid.orig_Update orig, Liquid self)
	{
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quickmud>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Crimquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Desert.Ebonquicksand>()] = true;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Pearlquicksand>()] = true;
		Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.PowderedSnow>()] = true;
        Main.tileSolid[ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Sinking.Gutquicksand>()] = true;
        orig.Invoke(self);
	}
}

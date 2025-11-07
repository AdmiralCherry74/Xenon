using System;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Common.Systems;

internal class BiomeTileCounts : ModSystem
{
	public int CorrosionTiles { get; private set; }
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Quicksand>()];
		Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<Ebonquicksand>()];
		Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<Crimquicksand>()];
		Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<Pearlquicksand>()];
		Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<PowderedSnow>()];
		Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<FrozenLava>()];

        CorrosionTiles = tileCounts[ModContent.TileType<Gutstone>()] +
                         tileCounts[ModContent.TileType<HardenedGutsand>()] +
                         tileCounts[ModContent.TileType<Gutsandstone>()] +
                         tileCounts[ModContent.TileType<CorrosionGrass>()] +
                         tileCounts[ModContent.TileType<CorrosionJungleGrass>()] +
                         tileCounts[ModContent.TileType<Gutsand>()] +
                         tileCounts[ModContent.TileType<TanIce>()];
    }
}

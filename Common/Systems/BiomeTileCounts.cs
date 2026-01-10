using System;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.Content.Tiles.Natural.Stone.Mossy;
using Xenon.ModSupport.Confection.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Confection.Content.Tiles.Natural.Stone.Mossy;

namespace Xenon.Common.Systems;

internal class BiomeTileCounts : ModSystem
{
    public int CorrosionTiles { get; private set; }
	public int FrozenLavaTiles { get; private set; }
    public int MountainTiles { get; set; }
    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Gutsand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Quicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Ebonquicksand>()];
        Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Crimquicksand>()];
		Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Pearlquicksand>()];
		Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Gutquicksand>()];
		Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<CreamQuicksand>()];
		Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<Ebonquicksand>()];
		Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<Crimquicksand>()];
		Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<Pearlquicksand>()];
		Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<PowderedSnow>()];
		Main.SceneMetrics.SnowTileCount += tileCounts[ModContent.TileType<FrozenLava>()];
		Main.SceneMetrics.JungleTileCount += tileCounts[ModContent.TileType<CorrosionJungleGrass>()];
		Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<NyxStone>()];
		Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<AresStone>()];
        Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<HelioStone>()];
		Main.SceneMetrics.EvilTileCount += tileCounts[ModContent.TileType<MossyNyxStone>()];
		Main.SceneMetrics.BloodTileCount += tileCounts[ModContent.TileType<MossyAresStone>()];
		Main.SceneMetrics.HolyTileCount += tileCounts[ModContent.TileType<MossyHelioStone>()];


		CorrosionTiles = tileCounts[ModContent.TileType<Gutstone>()] +
						 tileCounts[ModContent.TileType<HardenedGutsand>()] +
						 tileCounts[ModContent.TileType<Gutsandstone>()] +
						 tileCounts[ModContent.TileType<CorrosionGrass>()] +
						 tileCounts[ModContent.TileType<CorrosionJungleGrass>()] +
						 tileCounts[ModContent.TileType<Gutsand>()] +
						 tileCounts[ModContent.TileType<TanIce>()] +
						 tileCounts[ModContent.TileType<HephStone>()] +
						 tileCounts[ModContent.TileType<MossyHephStone>()];

        FrozenLavaTiles = tileCounts[ModContent.TileType<FrozenLava>()];

		MountainTiles = tileCounts[ModContent.TileType<OuranoStone>()] +
						tileCounts[ModContent.TileType<NyxStone>()] +
						tileCounts[ModContent.TileType<AresStone>()] +
						tileCounts[ModContent.TileType<HelioStone>()] +
						tileCounts[ModContent.TileType<HephStone>()] +
                        tileCounts[ModContent.TileType<HestiaStone>()] +
                        tileCounts[ModContent.TileType<MossyOuranoStone>()] +
                        tileCounts[ModContent.TileType<MossyNyxStone>()] +
                        tileCounts[ModContent.TileType<MossyAresStone>()] +
                        tileCounts[ModContent.TileType<MossyHelioStone>()] +
                        tileCounts[ModContent.TileType<MossyHephStone>()] +
                        tileCounts[ModContent.TileType<MossyHestiaStone>()];
    }
}

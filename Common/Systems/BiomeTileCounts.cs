using System;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles;

namespace Xenon.Common.Systems;

internal class BiomeTileCounts : ModSystem
{
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		Main.SceneMetrics.SandTileCount += tileCounts[ModContent.TileType<Quicksand>()];
	}
}

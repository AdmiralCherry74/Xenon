using Xenon.Content.Tiles;
using System.Collections.Generic;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Common;

internal class TileSets
{
	public static readonly HashSet<int> Stalac = new() { ModContent.TileType<RhyoliteStalactgmites>(), ModContent.TileType<FrozenLavaStalac>(), ModContent.TileType<CorrosionStalac>() };
	public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

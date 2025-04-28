using Xenon.Content.Tiles;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Xenon.Common;

internal class TileSets
{
	public static readonly HashSet<int> Stalac = new() { ModContent.TileType<RhyoliteStalactgmites>(), ModContent.TileType<FrozenLavaStalac>() };
	public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

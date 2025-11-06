using System.Collections.Generic;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;
using Xenon.Content.Tiles.NaturalTile.Snow;
using Xenon.Content.Tiles.NaturalTile.Stones;

namespace Xenon.Common;

internal class TileSets
{
	public static readonly HashSet<int> Stalac = new() { ModContent.TileType<RhyoliteStalactgmites>(), ModContent.TileType<FrozenLavaStalac>(), ModContent.TileType<CorrosionStalac>() };
	public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

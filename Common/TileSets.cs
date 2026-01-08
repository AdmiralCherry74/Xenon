using System.Collections.Generic;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Snow;
using Xenon.Content.Tiles.Natural.Stone;

namespace Xenon.Common;

internal class TileSets
{
	public static readonly HashSet<int> Stalac = new()
	{
		ModContent.TileType<RhyoliteStalactgmites>(),
		ModContent.TileType<FrozenLavaStalac>(),
		ModContent.TileType<GutstoneStalac>(),
		ModContent.TileType<OuranoStalac>(),
		ModContent.TileType<NyxStalac>(),
		ModContent.TileType<HephStalac>(),
		ModContent.TileType<AresStalac>(),
		ModContent.TileType<HelioStalac>()
	};
	public static readonly HashSet<int> Ice = new() { ModContent.TileType<FrozenLava>() };
}

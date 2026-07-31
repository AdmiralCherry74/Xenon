using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Walls.BuildingWalls.Stones;
using Xenon.Content.Walls.NaturalWalls.Stone;

namespace Xenon.Content.Biomes;

public class Rhyolite : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => -1;
	public override string BestiaryIcon => base.BestiaryIcon;
	public override bool IsBiomeActive(Player player)
	{
		return Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<RhyoliteWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<SmoothRhyoliteWallUnsafe>();
	}
}

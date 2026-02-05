using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones;

namespace Xenon.Content.Biomes;

public class Catacombs : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => MusicID.Eerie;
	public override string BestiaryIcon => base.BestiaryIcon;
	public override bool IsBiomeActive(Player player)
	{
		return Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<RedCatacombWallUnsafe>() && player.ZoneRockLayerHeight && ModContent.GetInstance<BiomeTileCounts>().CatacombTiles >= 10;
	}
}

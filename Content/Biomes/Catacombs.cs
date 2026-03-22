using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Content.Biomes;

public class Catacombs : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/CatacombsPlaceHolderSSA");
	public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
    public override bool IsBiomeActive(Player player)
	{
        return (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && ModContent.GetInstance<BiomeTileCounts>().CatacombTiles >= 250 &&
        (Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<RedCatacombWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<LavenderCatacombWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<CharcoalCatacombWallUnsafe>() ||
		Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<RedCatacombTileWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<LavenderCatacombTileWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<CharcoalCatacombTileWallUnsafe>() ||
		Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<RedCatacombSlabWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<LavenderCatacombSlabWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<CharcoalCatacombSlabWallUnsafe>());
	}
}

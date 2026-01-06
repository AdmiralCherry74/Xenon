using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class Corrosion : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.Corruption;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles >= 300 && (player.ZoneOverworldHeight || player.ZoneDirtLayerHeight);
    }
public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<CorrosionSurfaceBackgroundStyle>();
        }
    }
}
public class CorrosionUnderground : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.UndergroundCorruption;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles >= 300 && (player.ZoneOverworldHeight || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<CorrosionUndergroundBackgroundStyle>();
        }
    }
}
public class CorrosionIce : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.OtherworldlyCorruption;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles >= 300 && Main.SceneMetrics.SnowTileCount >= 1500 && (player.ZoneOverworldHeight || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
    }
}
public class CorrosionUndergroundIce : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.OtherworldlyUGCrimson;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles >= 300 && Main.SceneMetrics.SnowTileCount >= 1500 && (player.ZoneOverworldHeight || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
    }
}

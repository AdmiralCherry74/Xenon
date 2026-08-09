using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class Mountain : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => MusicID.OtherworldlyUnderground;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/MountainWaterStyle");

    public override bool IsBiomeActive(Player player)
	{
        return ModContent.GetInstance<BiomeTileCounts>().MountainTiles >= 1500 && (player.ZoneOverworldHeight || player.ZoneDirtLayerHeight);
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<MountainBackgroundStyle>();
        }
    }
}
public class UndergroundMountain : ModBiome
{
    //public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.OtherworldlyUnderground; //might change this in the future. who knows
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.Environment; //not sure what the best priority for it would be so
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/MountainWaterStyle");

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().MountainTiles >= 1 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight);
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<UndergroundMountainBackgroundStyle>();
        }
    }
}
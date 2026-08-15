using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class Autumn : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/AutumnEveryPlanetWeReachIsDeadPhase1Music"); //"What If 'Every Planet We Reach Was Dead' was on the first album?" is the song
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/AutumnWaterStyle");

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().AutumnTiles > 140 && (player.ZoneOverworldHeight || player.ZoneDirtLayerHeight);
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<AutumnBackgroundStyle>();
        }
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<UndergroundAutumnBackgroundStyle>();
        }
    }
}
public class UndergroundAutumn : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/AutumnEveryPlanetWeReachIsDeadPhase1Music");
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/AutumnWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().AutumnTiles >= 140 && (player.ZoneRockLayerHeight);
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<AutumnBackgroundStyle>();
        }
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<UndergroundAutumnBackgroundStyle>();
        }
    }
}
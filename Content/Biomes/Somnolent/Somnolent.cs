using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Content.Biomes.Somnolent;

public class Somnolent : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/SoundCheckGravitySomnolentPlaceholder");
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow; //not sure what the best priority for it would be so

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().SomnolentTiles >= 300 && !player.ZoneRockLayerHeight;
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<SomnolentBackgroundStyle>();
        }
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<UndergroundSomnolentBackgroundStyle>();
        }
    }
}
public class UndergroundSomnolent : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/StarshineUndergroundSomnolentPlaceholder");
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow; //not sure what the best priority for it would be so

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().SomnolentTiles >= 300 && player.ZoneRockLayerHeight;
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<SomnolentBackgroundStyle>();
        }
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            if (Main.screenPosition.Y / 16 < Main.UnderworldLayer - 196f && Main.screenPosition.Y / 16 > Main.rockLayer + 60)
            {
                if (Main.LocalPlayer.ZoneSnow)
                {
                    return ModContent.GetInstance<UndergroundSomnolentIceBackgroundStyle>();
                }
                return ModContent.GetInstance<UndergroundSomnolentBackgroundStyle>();
            }
            return default;
        }
    }
}
public class SomnolentUndergroundIce : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/StarshineUndergroundSomnolentPlaceholder");
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;
    //public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().SomnolentTiles >= 300 && Main.SceneMetrics.SnowTileCount >= 1500 && player.ZoneRockLayerHeight;
    }
}
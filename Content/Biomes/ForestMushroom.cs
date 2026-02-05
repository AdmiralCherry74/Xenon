using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class ForestMushroom : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	//public override string MapBackground => BackgroundPath;
	public override int Music => MusicID.Mushrooms;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;
    //public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/MountainWaterStyle");

    public override bool IsBiomeActive(Player player)
	{
        return ModContent.GetInstance<BiomeTileCounts>().ForestMushroomTiles > 100 && (player.ZoneOverworldHeight);
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<ForestMushroomBackgroundStyle>();
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class Mountain : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => MusicID.ConsoleMenu;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override bool IsBiomeActive(Player player)
	{
        return ModContent.GetInstance<BiomeTileCounts>().MountainTiles > 10 && (player.ZoneOverworldHeight || player.ZoneDirtLayerHeight);
    }
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<MountainBackgroundStyle>();
        }
    }
}
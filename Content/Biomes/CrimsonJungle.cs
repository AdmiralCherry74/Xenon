using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class CrimsonJungle : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.Crimson;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CrimsonJungleTiles > 300 && (player.ZoneOverworldHeight || player.ZoneDirtLayerHeight);
    }

    public class UndergroundCrimsonJungle : ModBiome
    {
        public override string MapBackground => BackgroundPath;
        public override int Music => MusicID.UndergroundCrimson;
        public override string BestiaryIcon => base.BestiaryIcon;
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override bool IsBiomeActive(Player player)
        {
            return ModContent.GetInstance<BiomeTileCounts>().CrimsonJungleTiles > 300 && (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
        }
    }
}
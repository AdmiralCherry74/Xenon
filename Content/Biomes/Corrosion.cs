using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class Corrosion : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.OtherworldlyCorruption;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Xenon/CorrosionWaterStyle");
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles >= 300 && player.ZoneOverworldHeight;
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Content.Biomes.UndergroundOcean;

public class UndergroundOcean : ModBiome
{
    //public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.Ocean; //might change this in the future. who knows
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium; //not sure what the best priority for it would be so

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().UndergroundOceanTiles >= 50 && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && (player.position.X / 16 < 300 || player.position.X / 16 > Main.maxTilesX - 300);
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<UndergroundOceanBackgroundStyle>();
        }
    }
}
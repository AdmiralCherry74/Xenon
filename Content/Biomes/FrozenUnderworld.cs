using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones;
using Xenon.Content.Walls.NaturalWalls.Stone;

namespace Xenon.Content.Biomes;

public class FrozenUnderworld : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.Ice;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().FrozenLavaTiles > 150 && player.ZoneRockLayerHeight;
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<FrozenUnderworldBackgroundStyle>();
        }
    }
}


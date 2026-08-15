using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Common.Globals.XenonWorldGlobals;
using Xenon.Common.Systems;

namespace Xenon.Content.Biomes;

public class ScorchingIce : ModBiome
{
    public override string BackgroundPath => base.BackgroundPath;
    public override string MapBackground => BackgroundPath;
    public override int Music => MusicID.Ice;
    public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().FrozenLavaTiles > 150 && player.ZoneRockLayerHeight && player.position.Y / 16 > ModContent.GetInstance<XenonWorld>().LavaLine - 150;
    }
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    {
        get
        {
            return ModContent.GetInstance<ScorchingIceBackgroundStyle>();
        }
    }
}


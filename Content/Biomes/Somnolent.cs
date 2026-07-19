using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

namespace Xenon.Content.Biomes;

public class Somnolent : ModBiome
{
    //public override string BackgroundPath => base.BackgroundPath;
    //public override string MapBackground => BackgroundPath;
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/SoundCheckGravitySomnolentPlaceholder");
    //public override string BestiaryIcon => base.BestiaryIcon;
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow; //not sure what the best priority for it would be so

    public override bool IsBiomeActive(Player player)
    {
        return ModContent.GetInstance<BiomeTileCounts>().SomnolentTiles > 300;
    }
    //public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
    //{
    //    get
    //    {
    //        return ModContent.GetInstance<TheMirageBackgroundStyle>();
    //    }
    //}
}
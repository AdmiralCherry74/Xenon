using Terraria.ModLoader;

namespace Xenon.Content.Biomes
{
    public class CorrosionUndergroundIceBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[1] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUndergroundIceBackground_1"); // Undeground layer. refered to as Dirt Layer in code
            textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUndergroundIceBackground_2"); // Underground-Cavern border. refered to as underground border in code
            textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUndergroundIceBackground_3"); // Cavern. refered to as Underground in code.
            textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUndergroundIceBackground_4"); // Hell border?
        }
    }
}
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonWorldGlobals;

namespace Xenon.Content.Biomes
{
    public class CorrosionUndergroundBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            if (XenonWorld.CorrosionUndergroundBG == 1)
            {
                textureSlots[0] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/LunesUG/CorrosionUndergroundBackground_0_0"); // Sky border
                textureSlots[1] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/LunesUG/CorrosionUndergroundBackground_0_1"); // Undeground layer. refered to as Dirt Layer in code
                textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/LunesUG/CorrosionUndergroundBackground_0_2"); // Underground-Cavern border. refered to as underground border in code
                textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/LunesUG/CorrosionUndergroundBackground_0_3"); // Cavern. refered to as Underground in code.
                textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/LunesUG/CorrosionUndergroundBackground_0_4"); // Hell border?
            }
            else
            {
                textureSlots[0] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/WaxsUG/CorrosionUndergroundBackground_1_0"); 
                textureSlots[1] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/WaxsUG/CorrosionUndergroundBackground_1_1");
                textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/WaxsUG/CorrosionUndergroundBackground_1_2");
                textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/WaxsUG/CorrosionUndergroundBackground_1_3");
                textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/CorrosionBackgrounds/CorrosionUnderground/WaxsUG/CorrosionUndergroundBackground_1_4"); 
            }
        }
    }
}
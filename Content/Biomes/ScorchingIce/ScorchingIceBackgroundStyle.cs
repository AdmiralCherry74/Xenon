using Terraria.ModLoader;

namespace Xenon.Content.Biomes.ScorchingIce
{
    public class ScorchingIceBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/FrozenUnderworldBackground_1"); // Underground-Cavern border. refered to as underground border in code
            textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/FrozenUnderworldBackground_2"); // Cavern. refered to as Underground in code.
            textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/FrozenUnderworldBackground_3"); // Hell border?
        }
    }
}
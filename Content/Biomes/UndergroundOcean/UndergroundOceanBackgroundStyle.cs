using Terraria.ModLoader;

namespace Xenon.Content.Biomes.UndergroundOcean
{
    public class UndergroundOceanBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/UndergroundOcean/PureOcean0_0"); // Sky border
            textureSlots[1] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/UndergroundOcean/PureOcean0_1"); // Undeground layer. refered to as Dirt Layer in code
            textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/UndergroundOcean/PureOcean0_2"); // Underground-Cavern border. refered to as underground border in code
            textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/UndergroundOcean/PureOcean0_3"); // Cavern. refered to as Underground in code.
            textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/UndergroundOcean/PureOcean0_4"); // Hell border?
        }
    }
}
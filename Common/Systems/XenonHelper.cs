using Terraria;
using Terraria.GameContent.ItemDropRules;
using Xenon.Common.Globals.XenonNPCGlobals;
using Xenon.Content.Biomes.Corrosion;

namespace Xenon.Common.Systems
{
    public static class XenonHelper
    {

        // Removes any instance of an item within an Int array
        // Thank you random StackOverflow Thread
        public static int[] RemoveIndices(int[] IndicesArray, int RemoveAt)
        {
            int[] newIndicesArray = new int[IndicesArray.Length - 1];

            int i = 0;
            int j = 0;
            while (i < IndicesArray.Length)
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j] = IndicesArray[i];
                    j++;
                }

                i++;
            }

            return newIndicesArray;
        }

        public static bool PlayerInCorrosion(Player player)
        {
            return player.InModBiome<Corrosion>() || player.InModBiome<CorrosionIce>() || player.InModBiome<CorrosionCaveDesert>() || player.InModBiome<CorrosionDesert>() || player.InModBiome<CorrosionUnderground>();
        }
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Waters.SparkBlocks;

public class GarnetWaterfallStyle : ModWaterfallStyle
{
    public override void AddLight(int i, int j) =>
             Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), new Vector3(0.714f * 0.8f, 0.15f * 0.8f, 0.45f * 0.8f) * 0.25f);
    public override void ColorMultiplier(ref float r, ref float g, ref float b, float a)
    {
        r = 255f * a;
        g = 255f * a;
        b = 255f * a;
    }
}
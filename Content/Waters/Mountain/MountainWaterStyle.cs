using Xenon.Content.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Waters.Mountain;

public class MountainWaterStyle : ModWaterStyle
{
	private Asset<Texture2D> rainTexture;
	public override void Load()
	{
		rainTexture = ModContent.Request<Texture2D>("Xenon/Content/Waters/Mountain/MountainRain");
	}
	public override int ChooseWaterfallStyle()
    {
        return Mod.Find<ModWaterfallStyle>("MountainWaterfallStyle").Slot;
    }

    public override int GetSplashDust()
    {
        return ModContent.DustType<MountainWaterSplash>();
    }

    public override int GetDropletGore()
    {
        return Mod.Find<ModGore>("MountainDroplet").Type;
    }

    public override void LightColorMultiplier(ref float r, ref float g, ref float b)
    {
        r = 1f;
        g = 1f;
        b = 1f;
    }

    public override Color BiomeHairColor()
    {
        return Color.DarkSlateBlue;
    }

    public override byte GetRainVariant()
    {
        return (byte)Main.rand.Next(3);
    }

    public override Asset<Texture2D> GetRainTexture()=> rainTexture;
}



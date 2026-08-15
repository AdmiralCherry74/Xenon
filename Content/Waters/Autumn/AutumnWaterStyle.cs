using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Waters.Autumn;

public class AutumnWaterStyle : ModWaterStyle
{
	private Asset<Texture2D> rainTexture;
	public override void Load()
	{
		rainTexture = ModContent.Request<Texture2D>("Xenon/Content/Waters/Autumn/AutumnRain");
	}
	public override int ChooseWaterfallStyle()
    {
        return Mod.Find<ModWaterfallStyle>("AutumnWaterfallStyle").Slot;
    }

    public override int GetSplashDust()
    {
        return ModContent.DustType<AutumnWaterSplash>();
    }

    public override int GetDropletGore()
    {
        return Mod.Find<ModGore>("AutumnDroplet").Type;
    }

    public override void LightColorMultiplier(ref float r, ref float g, ref float b)
    {
        r = 1f;
        g = 1f;
        b = 1f;
    }

    public override Color BiomeHairColor()
    {
        return Color.Orange;
    }

    public override byte GetRainVariant()
    {
        return (byte)Main.rand.Next(3);
    }

    public override Asset<Texture2D> GetRainTexture()=> rainTexture;
}



using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.ModLoader;

namespace Xenon.Common;

internal class XenonMenu : ModMenu
{
	public override Asset<Texture2D> Logo
	{
		get
		{
			if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
			{
                return Mod.Assets.Request<Texture2D>("Assets/Textures/UI/ArgonAprilFoolsLogo");
            }
			else if (DateTime.Now.Hour > 21 || DateTime.Now.Hour < 6)
			{
                return Mod.Assets.Request<Texture2D>("Assets/Textures/UI/XenonNightTimeLogo");
            }
			else
			{
                return Mod.Assets.Request<Texture2D>("Assets/Textures/UI/XenonLogo");
            }
		}
	}
}

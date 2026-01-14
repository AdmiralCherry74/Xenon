using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace Xenon.Common;

internal class XenonMenu : ModMenu
{
	public override Asset<Texture2D> Logo
	{
		get
		{
			return Mod.Assets.Request<Texture2D>("Assets/Textures/UI/XenonLogo");
		}
	}
}

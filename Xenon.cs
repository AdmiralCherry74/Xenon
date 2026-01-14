using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon;

public class XenonMod : Mod
{
	public static Color CorrosionBiomeSightColor = new Color(227, 236, 58);
	public const string TextureAssetsPath = "Assets/Textures";
	public static bool AvalonContentEnabled = ModLoader.HasMod("Avalon");
	public static bool TheConfectionRebirthContentEnabled = ModLoader.HasMod("TheConfectionRebirth");
	public override void Load()
	{
		while (ModHook.RegisteredHooks.TryDequeue(out ModHook? hook))
		{
			hook.ApplyHook();
		}
	}
}

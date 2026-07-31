using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using Terraria;
using Terraria.GameContent.RGB;
using Terraria.ModLoader;
using TheConfectionRebirth;
using TheConfectionRebirth.RGB;
using Xenon.Common;

namespace Xenon;

public class XenonMod : Mod
{
    public static Color CorrosionBiomeSightColor = new Color(227, 236, 58);
    public static Color SomnolentBiomeSightColor = new Color(10, 25, 75);
    public const string TextureAssetsPath = "Assets/Textures";
    public static bool FargowiltasContentEnabled = ModLoader.HasMod("Fargowiltas");
    public static bool FargowiltasSoulsContentEnabled = ModLoader.HasMod("FargowiltasSouls");
    public static bool AvalonContentEnabled = ModLoader.HasMod("Avalon");
    public static bool TheConfectionRebirthContentEnabled = ModLoader.HasMod("TheConfectionRebirth");
    public override void Load()
    {
        while (ModHook.RegisteredHooks.TryDequeue(out ModHook? hook))
        {
            hook.ApplyHook();
        }
        BackgroundReflectionUtilities.Load();
    }
    public override void Unload()
    {
        BackgroundReflectionUtilities.Unload();
    }
}

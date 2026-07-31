using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.ModSupport.Fargowiltas;

[ExtendsFromMod("Fargowiltas")]
internal class FargowiltasRenames : ModHook
{
    protected override void Apply()
    {
        On_Lang.GetItemName += On_Lang_GetItemName;
    }
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.FargowiltasContentEnabled;
    }
    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
    {
        return orig.Invoke(id);
    }
}
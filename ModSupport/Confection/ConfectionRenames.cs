using Avalon.Items.Placeable.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TheConfectionRebirth.Items.Placeable;
using Xenon.Common;

namespace Xenon.ModSupport.Confection;

[ExtendsFromMod("TheConfectionRebirth")]
internal class ConfectionRenames : ModHook
{
    protected override void Apply()
    {
        On_Lang.GetItemName += On_Lang_GetItemName;
    }
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.TheConfectionRebirthContentEnabled;
    }
    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
    {
        if (id == ModContent.ItemType<OrangeIce>() && XenonMod.TheConfectionRebirthContentEnabled)
        {
            return Language.GetText("Mods.Xenon.ModdedItemRenames.CreamIce");
        }
        return orig.Invoke(id);
    }
}
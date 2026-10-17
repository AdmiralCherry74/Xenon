using Avalon.Items.Placeable.Tile;
using CalamityFables.Content.Boss.MushroomCrabBoss;
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

[ExtendsFromMod("CalamityFables")]
internal class CalamityFablesRenames : ModHook
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
        if (id == ModContent.ItemType<Hookstaff>() && XenonMod.CalamityFablesContentEnabled)
        {
            return Language.GetText("Mods.Xenon.ModdedItemRenames.Hookstaff");
        }
        return orig.Invoke(id);
    }
}
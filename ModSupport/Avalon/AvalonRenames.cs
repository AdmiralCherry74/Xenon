using Avalon.Items.Ammo;
using Avalon.Items.Placeable.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.ModSupport.Avalon;

[ExtendsFromMod("Avalon")]
internal class AvalonRenames : ModHook
{
    protected override void Apply()
    {
        On_Lang.GetItemName += On_Lang_GetItemName;
    }
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
    {
        if (id == ModContent.ItemType<YellowIceBlock>() && XenonMod.AvalonContentEnabled)
        {
            return Language.GetText("Mods.Xenon.ModdedItemRenames.PlagueIce");
        }
        if (id == ModContent.ItemType<GreenIceBlock>() && XenonMod.AvalonContentEnabled)
        {
            return Language.GetText("Mods.Xenon.ModdedItemRenames.FloraIce");
        }
        if (id == ModContent.ItemType<ContagionSolution>() && XenonMod.AvalonContentEnabled)
        {
            return Language.GetText("Mods.Xenon.ModdedItemRenames.PlagueSolution");
        }
        return orig.Invoke(id);
    }
}
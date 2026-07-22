using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Hooks;

internal class ItemNameChange : ModHook
{
    protected override void Apply()
    {
        On_Lang.GetItemName += On_Lang_GetItemName;
    }

    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
    {
        if (id == ItemID.Hellstone && ModContent.GetInstance<XenonConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneRename");
        }
        if (id == ItemID.HellstoneBar && ModContent.GetInstance<XenonConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBarRename");
        }
        if (id == ItemID.HellstoneBrick && ModContent.GetInstance<XenonConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickRename");
        }
        if (id == ItemID.HellstoneBrickWall && ModContent.GetInstance<XenonConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickWallRename");
        }
        if (id == ItemID.LavaCrateHard && ModContent.GetInstance<XenonConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneCrateRename");
        }
        return orig.Invoke(id);
    }
}
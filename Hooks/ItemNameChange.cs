
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
        if (id == ItemID.Hellstone && ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneRename");
        }
        if (id == ItemID.HellstoneBar && ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBarRename");
        }
        if (id == ItemID.HellstoneBrick && ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickRename");
        }
        if (id == ItemID.HellstoneBrickWall && ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickWallRename");
        }
        if (id == ItemID.LavaCrateHard && ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneCrateRename");
        }
        if (id == ItemID.PlatinumCrown)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.AncientPlatinumCrown");
        }
        if (id == ItemID.Candelabra)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.GoldCandelabra");
        }
        if (id == ItemID.Candle)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.GoldCandle");
        }
        if (id == ItemID.PurpleIceBlock)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.EvilIce");
        }
        if (id == ItemID.RedIceBlock)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.FleshIce");
        }
        if (id == ItemID.PinkIceBlock)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HolyIce");
        }
        if (id == ItemID.GreenSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.PuritySolution");
        }
        if (id == ItemID.SandSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.DesertSolution");
        }
        if (id == ItemID.SnowSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.SnowSolution");
        }
        if (id == ItemID.DirtSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.ForestSolution");
        }
        if (id == ItemID.BlueSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.HallowSolution");
        }
        if (id == ItemID.PurpleSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.CorruptSolution");
        }
        if (id == ItemID.RedSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.CrimfiedSolution");
        }
        if (id == ItemID.DarkBlueSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.MushroomSolution");
        }
        if (id == ItemID.Prismite)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.PrismiteFish");
        }
        return orig.Invoke(id);
    }
}
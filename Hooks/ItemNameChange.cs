
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Ammo;
using Xenon.Content.Items.Placeable.Blocks.Natural.Snow;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Hooks;

internal class ItemNameChange : ModHook
{
    protected override void Apply()
    {
        On_Lang.GetItemName += On_Lang_GetItemName;
    }

    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
    {
        if (ModContent.GetInstance<XenonClientConfig>().HellstoneRename)
        {
            if (id == ItemID.Hellstone)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneRename");
            }
            if (id == ItemID.HellstoneBar)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBarRename");
            }
            if (id == ItemID.HellstoneBrick)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickRename");
            }
            if (id == ItemID.HellstoneBrickWall)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneBrickWallRename");
            }
            if (id == ItemID.LavaCrateHard)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HellstoneCrateRename");
            }
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

        if (id == ItemID.GrayBrick)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.StoneBrick");
        }
        if (id == ItemID.GrayBrickWall)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.StoneBrickWall");
        }
        if (id == ItemID.StonePlatform)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.StoneBrickPlatform");
        }
        if (id == ItemID.StoneDoor)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.StoneBrickDoor");
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
        if (id == ItemID.DarkBlueSolution)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.MushroomSolution");
        }

        if (ModContent.GetInstance<XenonClientConfig>().FancyRenames)
        {
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
            if (id == ModContent.ItemType<BrownIceBlock>())
            {
                return Language.GetText("Mods.Xenon.XenonItemRenames.ExpiredIce");
            }

            
            if (id == ItemID.BlueSolution)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.HallowSolutionFancy");
            }
            if (id == ItemID.PurpleSolution)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.CorruptSolutionFancy");
            }
            if (id == ItemID.RedSolution)
            {
                return Language.GetText("Mods.Xenon.VanillaItemRenames.CrimfiedSolutionFancy");
            }
            if (id == ModContent.ItemType<CorrosionSolution>())
            {
                return Language.GetText("Mods.Xenon.XenonItemRenames.CorrodedSolutionFancy");
            }
            if (id == ModContent.ItemType<AutumnSolution>())
            {
                return Language.GetText("Mods.Xenon.XenonItemRenames.AutumnSolutionFancy");
            }
            if (id == ModContent.ItemType<SnoozeSolution>())
            {
                return Language.GetText("Mods.Xenon.XenonItemRenames.SomnolentSolutionFancy");
            }
            if (id == ModContent.ItemType<IndigoIceBlock>())
            {
                return Language.GetText("Mods.Xenon.XenonItemRenames.IndigoIceFancy");
            }
        }
        else
        {
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
        }

        if (id == ItemID.Prismite)
        {
            return Language.GetText("Mods.Xenon.VanillaItemRenames.PrismiteFish");
        }
        return orig.Invoke(id);
    }
}
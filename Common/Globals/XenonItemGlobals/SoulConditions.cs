using Avalon.DropConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Biomes.Somnolent;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class PuritySoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public PuritySoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfRight");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.ZoneNormalCaverns;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
    public class CrimsonSoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public CrimsonSoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfSpite");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.ZoneCrimson && info.player.ZoneRockLayerHeight;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
    public class CorrosionSoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public CorrosionSoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfBlight");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.InModBiome<CorrosionUnderground>() && info.player.ZoneRockLayerHeight;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
    public class SomnolentSoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public SomnolentSoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfTwilight");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.InModBiome<UndergroundSomnolent>() && info.player.ZoneRockLayerHeight;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
    public class NewCorruptionSoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public NewCorruptionSoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfNight");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.ZoneCorrupt && info.player.ZoneRockLayerHeight;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
    public class NewHallowSoulConditions : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public NewHallowSoulConditions()
        {
            Description ??= Language.GetOrRegister("Mods.Xenon.DropConditions.SoulOfLight");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            NPC npc = info.npc;
            return Main.hardMode
                && !NPCID.Sets.CannotDropSouls[npc.type]
                && !npc.boss
                && !npc.friendly
                && npc.lifeMax > 1
                && npc.value >= 1
                && info.player.ZoneHallow && info.player.ZoneRockLayerHeight;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}
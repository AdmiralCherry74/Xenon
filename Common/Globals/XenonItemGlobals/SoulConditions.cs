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
using Xenon.Content.Biomes;

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
}

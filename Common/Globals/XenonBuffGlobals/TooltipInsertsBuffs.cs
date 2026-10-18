using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Weapons.Melee.Broadswords;

namespace Xenon.Common.Globals.XenonBuffGlobals
{
    public class TooltipInsertsBuffs : GlobalBuff
    {
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            //thanks Avalon
            if (type == BuffID.Flipper)
            {
                tip = tip.Replace(Language.GetTextValue("BuffDescription.Flipper"), Language.GetTextValue("Mods.Xenon.Buffs.FlipperBuffRelocalization"));
            }
            return;
        }
    }
}
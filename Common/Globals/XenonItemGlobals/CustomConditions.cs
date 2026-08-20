using Avalon.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public static class CustomConditions
    {
        public static Condition BakersHandbookPurityUsed = new("Mods.Xenon.Conditions.BakersHandbookPurityUsed", () => Main.LocalPlayer.GetModPlayer<BakersHandbooksBool>().BakersHandbookPurityUsed);
    }
}

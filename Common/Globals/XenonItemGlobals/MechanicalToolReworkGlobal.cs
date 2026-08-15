using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class MechanicalToolReworkGlobal : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (Data.ItemSets.MechanicalToolReworkItemSet[item.type] && ModContent.GetInstance<XenonConfig>().BasicProgressionChanges)
            {
                item.useAnimation = item.useTime = 3;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Common.MasterModeGlobals.XenonMMPlayerGlobals
{
    public class MasterModePlayerSimpleChanges : ModPlayer
    {
        public override void ModifyLuck(ref float luck)
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                Player.luck += 0.2f;
            }
        }
    }
}

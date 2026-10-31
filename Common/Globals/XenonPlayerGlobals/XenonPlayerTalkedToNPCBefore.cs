using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Xenon.Common.Globals.XenonPlayerGlobals
{
    public class XenonPlayerTalkedToNPCBefore : ModPlayer
    {
        public bool HaveWeTalkedToBakerBefore = false;

        public override void LoadData(TagCompound tag)
        {
            HaveWeTalkedToBakerBefore = tag.GetBool("HaveWeTalkedBeforeTagBaker");
        }

        public override void SaveData(TagCompound tag)
        {
            tag["HaveWeTalkedBeforeTagBaker"] = HaveWeTalkedToBakerBefore;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class ItemChanges : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item entity)
        {
            //Thank you Terradux
            if (entity.type == ItemID.Rally)
            {
                entity.damage = 18;
            }
        }
    }
}

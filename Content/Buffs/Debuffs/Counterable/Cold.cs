using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using static Xenon.Content.Buffs.Debuffs.Counterable.Gnashed;

namespace Xenon.Content.Buffs.Debuffs.Counterable
{
    public class Cold : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ColdUpdate>().ColdDebuff = true;
        }
    }
}

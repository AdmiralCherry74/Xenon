using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Common.MasterModeGlobals.XenonMMPlayerGlobals;

namespace Xenon.Content.Buffs.Debuffs.MasterModeExclusive
{
    //TBH the buff is for visual flair. it techincally doesnt even do anything
    public class Injured : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = false; // Causes this buff not to persist when exiting and rejoining the world
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.statLife <= (int)(player.statLifeMax2 * 0.25f))
            {
                player.buffTime[buffIndex] = 60;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}

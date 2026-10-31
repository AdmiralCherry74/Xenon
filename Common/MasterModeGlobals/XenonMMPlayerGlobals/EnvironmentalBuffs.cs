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
    public class EnvironmentalBuffs : ModPlayer
    {
        public override void PreUpdateBuffs()
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                if (Player.wet || (Main.raining && !Player.behindBackWall))
                {
                    Player.AddBuff(BuffID.Wet, 900);
                }

                if (Player.ZoneSnow || Player.frostBurn)
                {
                    Player.AddBuff(ModContent.BuffType<Cold>(), 900);
                }

                if (!NPC.downedBoss3 && Main.screenPosition.Y / 16 > Main.UnderworldLayer - 33)
                {
                    Player.AddBuff(BuffID.Darkness, 900);
                }
            }
        }
    }
}

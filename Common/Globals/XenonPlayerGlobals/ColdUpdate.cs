using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Common.Globals.XenonPlayerGlobals
{
    public class ColdUpdate : ModPlayer
    {
        public bool ColdDebuff;
        public override void ResetEffects()
        {
            ColdDebuff = false;
        }
        public override void PostUpdateEquips()
        {
            if (Player.buffImmune[BuffID.Chilled] || Player.frostArmor)
            {
                Player.resistCold = true;
                Player.buffImmune[ModContent.BuffType<Cold>()] = true;
            }    
        }
        public override void PostUpdateMiscEffects()
        {
            if (ColdDebuff)
            {
                Player.moveSpeed *= 0.90f;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.MasterModeExclusive;

namespace Xenon.Common.MasterModeGlobals.XenonMMPlayerGlobals
{
    public class PlayerInjured : ModPlayer
    {
        public bool LowHealth;

        public override void ResetEffects()
        {
            LowHealth = false;
        }
        public override void PostUpdateMiscEffects()
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                if (Player.statLife <= (int)(Player.statLifeMax2 * 0.25f))
                {
                    Player.AddBuff(ModContent.BuffType<Injured>(), 60);
                    LowHealth = true;
                }
            }

            if (LowHealth)
            {
                Player.lifeRegen = (int)(Player.lifeRegen * 1.2f);

                Player.moveSpeed *= 0.65f;
            }
        }
    }
}

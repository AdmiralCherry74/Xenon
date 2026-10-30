using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Xenon.Common.Systems
{
    public class XenonLoadingScreenTips : ModSystem
    {
        public override void ModifyGameTipVisibility(IReadOnlyList<GameTipData> gameTips)
        {
            #region Hide Vanilla Loading Tips for Corruption / Crimson / Hallow content
            gameTips[GameTipID.CorruptionCantSpreadInHallow].Hide();
            gameTips[GameTipID.PwnHammerForAltars].Hide();
            gameTips[GameTipID.ShadowOrbsDestruction].Hide();
            #endregion
        }
    }
}
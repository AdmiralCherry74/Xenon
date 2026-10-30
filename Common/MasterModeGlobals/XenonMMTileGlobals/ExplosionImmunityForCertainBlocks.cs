using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Common.MasterModeGlobals.XenonMMTileGlobals
{
    public class ExplosionImmunityForCertainBlocks : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                #region Corrupt / Crimfied / Corroded Blocks
                if (type == TileID.Ebonstone || type == TileID.Crimstone || type == ModContent.TileType<Gutstone>() || type == TileID.ShadowOrbs || type == ModContent.TileType<GastroOrb>())
                {
                    if (!NPC.downedBoss2)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                #endregion
                return true;
            }
            return true;
        }
    }
}

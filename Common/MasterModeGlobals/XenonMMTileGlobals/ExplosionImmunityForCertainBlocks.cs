using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Systems;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

namespace Xenon.Common.MasterModeGlobals.XenonMMTileGlobals
{
    public class ExplosionImmunityForCertainBlocks : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            if (ModContent.GetInstance<XenonConfig>().MasterModeChanges && Main.masterMode)
            {
                #region Ores
                if (type == TileID.Iron || type == ModContent.TileType<CinnabarOre>() || type == TileID.Lead || type == TileID.Silver || type == ModContent.TileType<IndiumOre>() || type == TileID.Tungsten || type == TileID.Gold || type == ModContent.TileType<FluoriteOre>() || type == TileID.Platinum)
                {
                    if (!NPC.downedSlimeKing)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                if (type == TileID.Demonite || type == ModContent.TileType<IngestaneOre>() || type == TileID.Crimtane)
                {
                    if (!NPC.downedBoss1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                #endregion

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

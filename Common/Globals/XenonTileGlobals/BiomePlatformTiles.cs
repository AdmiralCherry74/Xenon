using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Common.Globals.XenonTileGlobals
{
    public class BiomePlatformTiles : GlobalItem
    {
        public override void HoldItem(Item item, Player player)
        {
            if (player.GetModPlayer<XenonPlayer>().BiomePlatform == true)
            {
                //item.createTile;
            }
        } 
    }
}

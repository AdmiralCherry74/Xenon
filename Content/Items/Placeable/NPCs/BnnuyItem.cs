using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.NPCs.Other;
using Xenon.Content.NPCs.UndergroundMobs;

namespace Xenon.Content.Items.Placeable.NPCs
{
    public class BnnuyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bunny);
            Item.makeNPC = ModContent.NPCType<Bnnuy>();
        }
    }
}
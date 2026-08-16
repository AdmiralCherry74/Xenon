using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.NPCs.UndergroundMobs;

namespace Xenon.Content.Items.Placeable.NPCs
{
    public class GarnetSquirrelItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemSquirrelSapphire);
            Item.makeNPC = ModContent.NPCType<GarnetSquirrel>();
        }
    }
    public class JadeSquirrelItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemSquirrelAmethyst);
            Item.makeNPC = ModContent.NPCType<JadeSquirrel>();
        }
    }
    public class LapisSquirrelItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemSquirrelRuby);
            Item.makeNPC = ModContent.NPCType<LapisSquirrel>();
        }
    }
    public class FlintSquirrelItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemSquirrelAmber);
            Item.makeNPC = ModContent.NPCType<FlintSquirrel>();
        }
    }
}
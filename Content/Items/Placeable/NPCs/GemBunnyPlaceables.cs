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
    public class GarnetBunnyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemBunnySapphire);
            Item.makeNPC = ModContent.NPCType<GarnetBunny>();
        }
    }
    public class JadeBunnyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemBunnyAmethyst);
            Item.makeNPC = ModContent.NPCType<JadeBunny>();
        }
    }
    public class LapisBunnyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemBunnyRuby);
            Item.makeNPC = ModContent.NPCType<LapisBunny>();
        }
    }
    public class FlintBunnyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GemBunnyAmber);
            Item.makeNPC = ModContent.NPCType<FlintBunny>();
        }
    }
}
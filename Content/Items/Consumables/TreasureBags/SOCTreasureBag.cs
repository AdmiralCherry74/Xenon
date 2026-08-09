using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Accessories.Expert;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;

namespace Xenon.Content.Items.Consumables.TreasureBags
{
    public class SOCTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;

            Item.ResearchUnlockCount = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.expert = true;
        }

        public override bool CanRightClick() => true;
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            if (Main.masterMode)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GastricCloak>(), 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<IngestaneOre>(), 1, 110, 135));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FreshChyme>(), 1, 30, 50));
                itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 7, 7));
                itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 50));
            }
            else
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GastricCloak>(), 1, 1, 1));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<IngestaneOre>(), 1, 80, 110));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FreshChyme>(), 1, 20, 40));
                itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 7, 7));
                itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 50, 50));
            }
        }
    }
}
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
using Xenon.Content.Items.Weapons.Ranged.Bows;
using Xenon.Content.Items.Weapons.Ranged.Equipment.Lethals;

namespace Xenon.Content.Items.Consumables.TreasureBags
{
    public class KingGrubbyTreasureBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bowquet>(), 5, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Grubnade>(), 3, 5, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 6, 6));
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 25, 25));
        }
    }
}
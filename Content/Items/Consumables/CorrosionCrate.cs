using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Weapons.Ranged.Arms;
using Xenon.Content.Items.Weapons.Melee.Boomerangs;
using Xenon.Content.Items.Weapons.Magic.Staves;
using Xenon.Content.Items.Pets;
using Xenon.Content.Tiles.Furniture;

namespace Xenon.Content.Items.Consumables;

public class CorrosionCrate : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.IsFishingCrate[Type] = true;
        Item.ResearchUnlockCount = 5;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CorrosionCrateTile>());
        Item.placeStyle = 0;
        Item.width = 12; //The hitbox dimensions are intentionally smaller so that it looks nicer when fished up on a bobber
        Item.height = 12;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(0, 1);
    }

    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
    }

    public override bool CanRightClick()
    {
        return true;
    }

    public override void ModifyItemLoot(ItemLoot itemLoot)
    {
        int[] themedDrops = new int[] {
            ModContent.ItemType<BiliaryShield>(),
            ModContent.ItemType<AUG>(),
            ModContent.ItemType<Phlegmarang>(),
            ModContent.ItemType<RottingLeftovers>(),
            ModContent.ItemType<SewerFury>(),
        };
        itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops));

        // Drop coins
        itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 5, 12));

        IItemDropRule[] oreTypes = new IItemDropRule[] {
            ItemDropRule.Common(ItemID.CopperOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.TinOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.IronOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.LeadOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.SilverOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.TungstenOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.GoldOre, 1, 20, 35),
            ItemDropRule.Common(ItemID.PlatinumOre, 1, 20, 35),
        };
        itemLoot.Add(new OneFromRulesRule(7, oreTypes));

        IItemDropRule[] oreBars = new IItemDropRule[] {
            ItemDropRule.Common(ItemID.IronBar, 1, 6, 16),
            ItemDropRule.Common(ItemID.LeadBar, 1, 6, 16),
            ItemDropRule.Common(ItemID.SilverBar, 1, 6, 16),
            ItemDropRule.Common(ItemID.TungstenBar, 1, 6, 16),
            ItemDropRule.Common(ItemID.GoldBar, 1, 6, 16),
            ItemDropRule.Common(ItemID.PlatinumBar, 1, 6, 16),
        };
        itemLoot.Add(new OneFromRulesRule(4, oreBars));

        IItemDropRule[] explorationPotions = new IItemDropRule[] {
            ItemDropRule.Common(ItemID.ObsidianSkinPotion, 1, 2, 4),
            ItemDropRule.Common(ItemID.SpelunkerPotion, 1, 2, 4),
            ItemDropRule.Common(ItemID.HunterPotion, 1, 2, 4),
            ItemDropRule.Common(ItemID.GravitationPotion, 1, 2, 4),
            ItemDropRule.Common(ItemID.MiningPotion, 1, 2, 4),
            ItemDropRule.Common(ItemID.HeartreachPotion, 1, 2, 4),
        };
        itemLoot.Add(new OneFromRulesRule(4, explorationPotions));

        IItemDropRule[] resourcePotions = new IItemDropRule[] {
            ItemDropRule.Common(ItemID.HealingPotion, 1, 5, 17),
            ItemDropRule.Common(ItemID.ManaPotion, 1, 5, 17),
        };
        itemLoot.Add(new OneFromRulesRule(2, resourcePotions));

        IItemDropRule[] highendBait = new IItemDropRule[] {
            ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 6),
            ItemDropRule.Common(ItemID.MasterBait, 1, 2, 6),
        };
        itemLoot.Add(new OneFromRulesRule(2, highendBait));
    }
}
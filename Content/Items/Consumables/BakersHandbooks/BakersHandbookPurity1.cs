using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Consumables.BakersHandbooks;

public class BakersHandbookPurity1 : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }
    public override void SetDefaults()
    {
        Item.value = Item.buyPrice(silver: 5);
        Item.rare = ItemRarityID.White;
        Item.consumable = true;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.UseSound = SoundID.Item1;
        Item.maxStack = 9999;
    }
    public override bool? UseItem(Player player)
    {
        return player.GetModPlayer<BakersHandbooksBool>().BakersHandbookPurityUsed = true;
    }
    public override bool CanUseItem(Player player)
    {
        if (player.GetModPlayer<BakersHandbooksBool>().BakersHandbookPurityUsed == true)
        {
            return false;
        }
        return true;
    }
}
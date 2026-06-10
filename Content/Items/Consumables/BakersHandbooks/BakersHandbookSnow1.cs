using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Consumables.BakersHandbooks;

public class BakersHandbookSnow1 : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Item.value = Item.buyPrice(silver: 5);
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 9999;
    }
}
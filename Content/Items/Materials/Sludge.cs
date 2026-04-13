using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Sludge : ModItem
{
    //dropped from Toxic Sludges. not sure what else to do with it right now other than make Bogged Pearlwood
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Item.value = Item.buyPrice(copper: 5);
        Item.rare = ItemRarityID.Green;
        Item.maxStack = 9999;
    }
}
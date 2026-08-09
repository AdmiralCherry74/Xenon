using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Sludge : ModItem
{
    //dropped from Toxic Sludges. not sure what else to do with it right now other than make Bogged Pearlwood
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Orange;
    }
}
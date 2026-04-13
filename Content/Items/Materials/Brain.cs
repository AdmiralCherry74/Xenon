using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Brain : ModItem
{
    //Catacomb alternative to Bones
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Item.value = Item.buyPrice(copper: 10);
        Item.rare = ItemRarityID.White;
        Item.maxStack = 9999;
    }
}
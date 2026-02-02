using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class BrokenPickaxeHead : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 20;
        Item.value = Item.buyPrice(copper: 1);
        Item.rare = ItemRarityID.Blue;
    }
}
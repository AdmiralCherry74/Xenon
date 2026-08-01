using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials.WorldInfectionMaterials;

public class FreshChyme : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.maxStack = 9999;
    }
}
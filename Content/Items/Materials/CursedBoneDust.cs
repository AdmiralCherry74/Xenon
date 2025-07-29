using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class CursedBoneDust : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.rare = 3;
        Item.value = Item.buyPrice(silver: 5);
    }
}
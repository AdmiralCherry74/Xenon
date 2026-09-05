using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables.Goods
{
    public class Perfume : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Item.buyPrice(gold: 2);
            Item.maxStack = 9999;
        }
    }
}
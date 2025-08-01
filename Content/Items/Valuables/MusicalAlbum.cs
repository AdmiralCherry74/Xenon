using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
{
    public class MusicalAlbum : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Terraria.Item.buyPrice(gold: 50);
        }
    }
}
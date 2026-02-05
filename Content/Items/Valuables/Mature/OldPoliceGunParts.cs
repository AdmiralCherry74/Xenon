using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables.Mature
{
    public class OldPoliceGunParts : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Evil>();
            Item.value = Item.buyPrice(silver: 1750);
        }
    }
}
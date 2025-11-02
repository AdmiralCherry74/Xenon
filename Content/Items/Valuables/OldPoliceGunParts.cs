using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
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
            Item.value = Terraria.Item.buyPrice(silver: 1750);
        }
    }
}
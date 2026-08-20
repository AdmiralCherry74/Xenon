using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Accessories
{
    public class TreeStar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 2;

            //if (Main.rand.Next(3) == 2)
            //{
            //    player.manaCost /= 3;
            //}
        }
    }
}
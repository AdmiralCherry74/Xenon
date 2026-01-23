using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Accessories.Immunity
{
    public class Medkit : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 1);
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<Gnashed>()] = true;
        }
    }
}
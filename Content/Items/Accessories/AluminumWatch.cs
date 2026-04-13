using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Accessories
{
    //[AutoloadEquip(EquipType.Waist)]
    public class AluminumWatch : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 4);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }
    }
}
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
    public class FluoriteWatch : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 3) player.accWatch = 3;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.accWatch < 3) player.accWatch = 3;
        }
    }
}
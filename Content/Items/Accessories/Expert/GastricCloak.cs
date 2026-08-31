using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.ModSupport.Avalon;

namespace Xenon.Content.Items.Accessories.Expert
{

    //[AutoloadEquip(EquipType.Back)]
    public class GastricCloak : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 22;
            Item.width = 26;
            Item.DefaultToAccessory();
            Item.sellPrice(gold: 2);
            Item.expert = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;
            player.manaRegenBonus += 3;
            player.GetModPlayer<XenonPlayer>().GastricCloakOn = true; //explicitly here for Avalon support. and maybe future stat regen increases aswell
        }
    }
}
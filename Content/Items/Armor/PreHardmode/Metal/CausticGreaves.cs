using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal
{

    [AutoloadEquip(EquipType.Legs)]
    public class CausticGreaves : ModItem
    {
        private const int PercentIncrease = 4;

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;

            Item.defense = 6;

            Item.value = Item.sellPrice(0, 0, 52, 5); // (Platinum, Gold, Silver, Copper)
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
        }
    }
}
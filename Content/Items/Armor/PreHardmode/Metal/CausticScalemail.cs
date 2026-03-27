using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal
{

    [AutoloadEquip(EquipType.Body)]
    public class CausticScalemail : ModItem
    {
        private const int PercentIncrease = 4;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 20;

            Item.defense = 7;

            Item.value = Item.sellPrice(0, 0, 70, 0); // (Platinum, Gold, Silver, Copper)
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
        }
    }
}
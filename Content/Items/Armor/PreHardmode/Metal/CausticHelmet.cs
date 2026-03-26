using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal
{

    [AutoloadEquip(EquipType.Head)]
    public class CausticHelmet : ModItem
    {
        private const int PercentIncrease = 4;

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 20;

            Item.defense = 6;

            Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 15)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
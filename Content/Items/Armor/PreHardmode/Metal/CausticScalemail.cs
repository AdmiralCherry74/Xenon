using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.EvilMaterials;
using Xenon.Content.Items.Materials.OresBarsGems;

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
            Item.value = Item.sellPrice(0, 0, 70, 0); // (Platinum, Gold, Silver, Copper)
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 25)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 20)
                .AddRecipeGroup("GoldChainmail", 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials
{
    public class RefinedBoneDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(silver: 10);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Pouch>())
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ModContent.ItemType<CursedBoneDust>(), 5)
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}
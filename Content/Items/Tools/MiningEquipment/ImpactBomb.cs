using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Projectiles.Tools.MiningEquipment;

namespace Xenon.Content.Items.Tools.MiningEquipment
{
    public class ImpactBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 5f;
            Item.shoot = ModContent.ProjectileType<ImpactBombProj>(); //The Tooltip is a reference to the beggining of 'Left Hand Suzuki Method' by The Gorillaz
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Bomb)
                .AddIngredient(ModContent.ItemType<WhiteGel>())
                .SortAfterFirstRecipesOf(ItemID.BouncyBomb)
                .Register();
        }
    }
}

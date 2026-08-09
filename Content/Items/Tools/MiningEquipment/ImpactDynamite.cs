using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Projectiles.Tools.MiningEquipment;

namespace Xenon.Content.Items.Tools.MiningEquipment
{
    public class ImpactDynamite : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<ImpactDynamiteProj>(); //The Tooltip is a reference to the beggining of 'Left Hand Suzuki Method' by The Gorillaz
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Dynamite)
                .AddIngredient(ModContent.ItemType<WhiteGel>())
                .SortAfterFirstRecipesOf(ItemID.BouncyDynamite)
                .Register();
        }
    }
}

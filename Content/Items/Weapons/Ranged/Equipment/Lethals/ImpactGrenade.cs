using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Projectiles.Ranged.Equipment.Lethal;
using Xenon.Content.Projectiles.Tools.MiningEquipment;

namespace Xenon.Content.Items.Weapons.Ranged.Equipment.Lethals
{
    public class ImpactGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 5.5f;
            Item.shoot = ModContent.ProjectileType<ImpactGrenadeProj>();
            Item.width = 10;
            Item.height = 26;
            Item.damage = 60;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient(ItemID.Grenade, 2)
                .AddIngredient(ModContent.ItemType<WhiteGel>())
                .SortAfterFirstRecipesOf(ItemID.BouncyGrenade)
                .Register();
        }
    }
}
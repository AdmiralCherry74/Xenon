using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Projectiles.Ranged.Equipment.Lethal;

namespace Xenon.Content.Items.Weapons.Ranged.Equipment.Lethals
{
    public class FrostNade : ModItem
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
            Item.shoot = ModContent.ProjectileType<FrostNadeProj>();
            Item.width = 10;
            Item.height = 26;
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ItemID.Snowball, 1)
                .AddIngredient(ModContent.ItemType<FrozenLava>(), 1)
                .AddIngredient(ItemID.Grenade, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
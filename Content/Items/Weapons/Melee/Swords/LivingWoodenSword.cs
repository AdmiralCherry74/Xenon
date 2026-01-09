using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class LivingWoodenSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 19;
        Item.useAnimation = 19;
        Item.autoReuse = false;
        Item.useTurn = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 17;
        Item.knockBack = 6.5f;
        Item.crit = 0;

        Item.value = Item.sellPrice(silver: 27);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBroadsword)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Ruby)
            .AddTile(TileID.LivingLoom)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBroadsword)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Diamond)
            .AddTile(TileID.LivingLoom)
            .Register();
    }
}
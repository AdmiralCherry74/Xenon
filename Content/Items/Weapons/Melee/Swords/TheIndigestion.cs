using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class TheIndigestion : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 19;
        Item.knockBack = 5;
        Item.crit = 0;

        Item.value = Item.sellPrice(silver: 27);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<UlceriteBar>(), 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
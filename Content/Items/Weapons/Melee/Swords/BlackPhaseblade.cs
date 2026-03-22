using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class BlackPhaseblade : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 48;
        Item.height = 48;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 18;
        Item.useAnimation = 18;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 26;
        Item.knockBack = 3;
        Item.crit = 0;

        Item.value = Item.buyPrice(silver: 54);
        Item.UseSound = SoundID.Item15;
        Item.rare = ItemRarityID.Blue;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.MeteoriteBar, 15)
            .AddIngredient(ModContent.ItemType<Lapis>(), 10)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
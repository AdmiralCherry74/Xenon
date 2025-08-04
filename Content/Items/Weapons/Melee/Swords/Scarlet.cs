using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class Scarlet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;

        Item.value = Item.buyPrice(gold: 10);
        Item.UseSound = SoundID.Item1;
        Item.rare = 2;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.BrokenArmor, 60);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 10)
            .AddIngredient(ItemID.GoldShortsword, 1)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
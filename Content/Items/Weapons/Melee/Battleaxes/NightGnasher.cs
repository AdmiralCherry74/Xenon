using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class NightGnasher : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 15;
        Item.knockBack = 4.5f;
        Item.crit = 6;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = 2;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 360);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 9)
            .AddIngredient(ItemID.ShadowScale, 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
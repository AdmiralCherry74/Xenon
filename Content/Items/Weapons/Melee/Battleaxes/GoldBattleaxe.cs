using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class GoldBattleaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 36;
        Item.height = 36;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 14;
        Item.knockBack = 6;
        Item.crit = 2;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = 0;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 180);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 9)
            .AddTile(TileID.Anvils)
            .Register();
    }
}